using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EcoHunt.Database
{
    public class FirebaseDatabase : DatabaseQueries
    {
        public static void TransferNameToGarbageFoundCategory(string name)
        {
            CheckForConnection();
            var values = GetValuesAssociatedWithName(name);

            InsertPictureIntoPicturesWithGarbage(values.name, values.url);
            DeletePicture(values.ID);
        }
        public static void InsertPictureIntoPicturesWithGarbage(string _name, string _url)
        {
            CheckForConnection();
            int newNum = GetNumberOfPicturesWithGarbage() + 1;


            NamesValues newThing = new NamesValues { name =  _name, url = _url, ID = newNum };


            InsertData("NamesWithGarbage/" + newThing.ID, newThing);
            SetNumberOfPicturesWithGarbage(newThing.ID);
        }
        public static NamesValues GetValuesAssociatedWithName(string name)
        {
            CheckForConnection();
            var allNames = GetAllPictureNames();

            for (int x = 0; x < allNames.Length; x++)
            {
                if (allNames[x].name == name)
                {
                    return allNames[x];
                }
            }
            return null;
        }
        public static NamesValues GetValuesAssociatedWithGarbagePicture(string name)
        {
            CheckForConnection();
            var allNames = GetAllPictureWithGarbageNames();

            for (int x = 0; x < allNames.Length; x++)
            {
                if (allNames[x].name == name)
                {
                    return allNames[x];
                }
            }
            return null;
        }
        public static NamesValues[] GetAllPictureWithGarbageNames()
        {
            CheckForConnection();
            var response = GetData("NamesWithGarbage");
            object json = JsonConvert.DeserializeObject(response.Body);

            List<NamesValues> values = new List<NamesValues>();
            foreach (JToken item in ((JToken)(json)).Children())
            {
                var newPatchNote = item.ToObject<NamesValues>();
                values.Add(newPatchNote);
            }

            for (int x = values.Count - 1; x >= 0; x--)
            {
                if (values[x] == null)
                    values.RemoveAt(x);
            }

            return values.ToArray();
        }
        public static NamesValues[] GetAllPictureNames()
        {
            CheckForConnection();
            var response = GetData("Names");
            object json = JsonConvert.DeserializeObject(response.Body);

            if (json == null)
                return null;

            List<NamesValues> values = new List<NamesValues>();
            foreach (JToken item in ((JToken)(json)).Children())
            {
                NamesValues newPatchNote = null;
                try
                {
                    newPatchNote = item.ToObject<NamesValues>();
                }
                catch
                {
                    try
                    {
                        var x = item.Children()[0];
                        var token = (JToken)x;
                        newPatchNote = token.ToObject<NamesValues>();
                    }
                    catch
                    {
                        var x = (JProperty)item;
                        var y = x.Value<JProperty>();

                        var children = y.Children();
                        newPatchNote = new NamesValues();
                        foreach (var child in children.First().Children())
                        {
                            var prop = (JProperty)child;
                            if (prop.Name == "name")
                                newPatchNote.name = prop.Value.ToString();
                            else if (prop.Name == "url")
                                newPatchNote.url = prop.Value.ToString();
                            else if (prop.Name == "ID")
                                newPatchNote.ID = Convert.ToInt32(prop.Value.ToString());
                        }
                    }
                }
                values.Add(newPatchNote);
            }

            for (int x = values.Count - 1; x >= 0; x--)
            {
                if (values[x] == null)
                    values.RemoveAt(x);
            }

            return values.ToArray();
        }
        public static void DeletePicture(string pictureName)
        {
            CheckForConnection();
            var allNames = GetAllPictureNames();
            for(int x = 0; x < allNames.Length; x++)
            {
                if(allNames[x].name == pictureName)
                {
                    DeletePicture(allNames[x].ID);
                    break;
                }
            }
        }
        public static void DeletePicture(int pictureIndex)
        {
            CheckForConnection();
            int currentNum = GetNumberOfNames();

            DeleteData("Names/" + pictureIndex);

            try
            {
                if (currentNum == pictureIndex)
                    SetNumberOfNames(GetAllPictureNames().Last().ID);
            }
            catch
            {
                //threre are no picture names
            }
        }
        public static void DeletePictureFromGarbage(string name)
        {
            var pic = GetValuesAssociatedWithGarbagePicture(name);
            DeletePictureFromGarbage(pic.ID);
        }
        public static void DeletePictureFromGarbage(int pictureIndex)
        {
            CheckForConnection();
            int currentNum = GetNumberOfPicturesWithGarbage();

            DeleteData("NamesWithGarbage/" + pictureIndex);

            try
            { 
                if (currentNum == pictureIndex)
                    SetNumberOfPicturesWithGarbage(GetAllPictureWithGarbageNames().Last().ID);
            }
            catch
            {
                //threre are no names
            }
        }

        public static int GetNumberOfNames()
        {
            CheckForConnection();
            return Convert.ToInt32(client.Get("NumberOfNames").Body);
        }
        private static void SetNumberOfNames(int number)
        {
            CheckForConnection();
            InsertData("NumberOfNames", number);
        }
        public static int GetNumberOfPicturesWithGarbage()
        {
            CheckForConnection();
            return Convert.ToInt32(client.Get("NumberOfPicturesWithGarbage").Body);
        }
        private static void SetNumberOfPicturesWithGarbage(int number)
        {
            CheckForConnection();
            InsertData("NumberOfPicturesWithGarbage", number);
        }
        public static void AddUrlToPicture(string pictureName, string url)
        {
            var allNames = GetAllPictureNames();
            for(int x = 0; x < allNames.Length; x++)
            {
                if (allNames[x].name == pictureName)
                {
                    allNames[x].url = url;
                    //DeletePicture(allNames[x].name);
                    //AddPicture(allNames[x].name, allNames[x].ID, url);
                    UpdateData("Names/" + allNames[x].ID, allNames[x]);
                }
            }
        }
        public static void AddUrlsToPicturesWithoutUrls()
        {
            var allNames = GetAllPictureNames();
            for(int x = 0; x < allNames.Length; x++)
            {
                if (allNames[x].url == null || String.IsNullOrWhiteSpace(allNames[x].url) == true)
                {
                    string url = FirebaseCloudStorage.GetUrlForPhoto(allNames[x].name + ".jpg");
                    AddUrlToPicture(allNames[x].name, url);
                }
            }
        }
        public static void AddPicture(string picName)
        {
            CheckForConnection();
            int newID = GetNumberOfNames() + 1;

            NamesValues stuffToInput = new NamesValues { ID = newID, name = picName };

            InsertData("Names/" + stuffToInput.ID, stuffToInput);
            SetNumberOfNames(newID);
        }
        private static void AddPicture(string picName, int id, string Url)
        {
            CheckForConnection();
            NamesValues stuffToInput = new NamesValues { ID = id, url = Url, name = picName };
            InsertData("Names/" + stuffToInput.ID, stuffToInput);
        }
    }
    public class NamesValues
    {
        public string name;
        public int ID;
        public string url;
    }
}