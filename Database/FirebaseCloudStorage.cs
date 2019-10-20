using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace EcoHunt.Database
{
    public class FirebaseCloudStorage
    {
        public static string AddPhotoToStorage(string fullFilePath)
        {
            var task = Task.Run(async () => await
                   Database.FirebaseCloudStorage.AddPhoto(fullFilePath)
                   );

            task.Wait();
            return task.Result;
        }
        public static string GetUrlForPhoto(string photoName)
        {
            try
            {
                var task = Task.Run(async () => await
                       Database.FirebaseCloudStorage.GetDownloadLink(photoName)
                       );

                task.Wait();
                return task.Result;
            }
            catch
            {
                return null;
            }
        }
        public static bool DeletePhotoFromStorage(string photoName)
        {
            try
            {
                var task = Task.Run(async () => await
                       Database.FirebaseCloudStorage.DeletePhoto(photoName)
                       );

                task.Wait();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string[] GetAllPhotoLinks()
        {
            var allNames = Database.FirebaseDatabase.GetAllPictureNames();

            List<string> links = new List<string>();
            for(int x = 0; x < allNames.Length; x++)
            {
                links.Add(allNames[x].url);
            }
            return links.ToArray();
        }
        private static async Task<string> AddPhoto(string file)
        {
            var fileUpload = File.Open(file, FileMode.Open);
            FileStream fs;
            string nameWithExtension = null;
            if (fileUpload.Length > 0)
            {
                fs = fileUpload;

                var auth = new FirebaseAuthProvider(new FirebaseConfig(API_Keys.cloudStorageApikey));
                var a = await auth.SignInWithEmailAndPasswordAsync(API_Keys.cloudStorageEmail, API_Keys.cloudStoragePassword);
                nameWithExtension = $"{fileUpload.Name.Split(Path.DirectorySeparatorChar).Last()}";

                var cancellation = new CancellationTokenSource();
                var upload = new FirebaseStorage(
                    API_Keys.cloudStorageBucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                        ThrowOnCancel = true
                    }
                    )
                    .Child("Pictures")
                    .Child(nameWithExtension)
                    .PutAsync(fs, cancellation.Token);

                string link = await upload;

                string name = nameWithExtension.Remove(nameWithExtension.IndexOf("."));
                fileUpload.Close();
                return link;
            }
            fileUpload.Close();
            return null;
        }
        public static string GetImageNamesFromFile(string url)
        {
            try
            {
                WebClient wc = new WebClient();
                return wc.DownloadString(url);
            }
            catch
            {
                return null;
            }
        }
        public static void CheckForNewFiles(string filePath)
        {
            string downloadUrl = String.Empty;
            try
            {
                var task = Task.Run(async () => await
                       GetDownloadLink("ImageNames.txt")
                       );

                task.Wait();
                downloadUrl = task.Result;
            }
            catch
            {
                return;
            }
            

            string allNames = GetImageNamesFromFile(downloadUrl);
            if (allNames == null)
                return;


            string[] parts = allNames.Split(',');
            if (parts.Length > 1)
            {

                string[] allNewFileNames = new string[parts.Length - 1];
                for (int x = 1; x < parts.Length; x++)
                {
                    allNewFileNames[x - 1] = parts[x];
                    Database.FirebaseDatabase.AddPicture(parts[x].Replace(".jpg", String.Empty));
                }
                Database.FirebaseDatabase.AddUrlsToPicturesWithoutUrls();






                var allnames = allNewFileNames;
                if (allnames != null)
                {
                    if (allNames.Length > 0)
                    {
                        for (int x = 0; x < allnames.Length; x++)
                        {
                            var name = Database.FirebaseDatabase.GetValuesAssociatedWithName(allnames[x].Replace(".jpg", String.Empty));

                            bool abc = GetGarbage.CheckGarbage(name.url);
                            if (!abc)//if it isn't garbage
                            {
                                Database.FirebaseDatabase.DeletePicture(name.ID);
                                DeletePhotoFromStorage(name.name + ".jpg");
                            }
                        }
                    }
                }

                ClearImageNameFile(filePath);
            }
        }
        public static void ClearImageNameFile(string filePath)
        {
            DeletePhotoFromStorage("ImageNames.txt");
            AddPhotoToStorage(filePath);
        }
        private static async Task<string> GetDownloadLink(string photoName)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(API_Keys.cloudStorageApikey));
            var a = await auth.SignInWithEmailAndPasswordAsync(API_Keys.cloudStorageEmail, API_Keys.cloudStoragePassword);

            var deleting = new FirebaseStorage(
                API_Keys.cloudStorageBucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child("Pictures")
                .Child(photoName)
                .GetDownloadUrlAsync();

            string link = await deleting;
            return link;
        }
        private static async Task DeletePhoto(string photoName)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(API_Keys.cloudStorageApikey));
            var a = await auth.SignInWithEmailAndPasswordAsync(API_Keys.cloudStorageEmail, API_Keys.cloudStoragePassword);

            var deleting = new FirebaseStorage(
                API_Keys.cloudStorageBucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child("Pictures")
                .Child(photoName)// + ".jpg")
                .DeleteAsync();

            await deleting;
        }
    }
}