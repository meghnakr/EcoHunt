using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcoHunt.Database
{
    public class FirebaseDatabase : DatabaseQueries
    {
        public static NamesValues[] GetAllPictureNames()
        {
            CheckForConnection();
            var response = GetData("Names");
            object json = JsonConvert.DeserializeObject(response.Body);

            List<NamesValues> patchNotes = new List<NamesValues>();
            foreach (JToken item in ((JToken)(json)).Children())
            {
                var newPatchNote = item.ToObject<NamesValues>();
                patchNotes.Add(newPatchNote);
            }

            for(int x = 0; x < patchNotes.Count(); x++)
            {
                if (patchNotes[x] == null)
                    patchNotes.RemoveAt(x);
            }

            return patchNotes.ToArray();
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

            if (currentNum == pictureIndex)
                SetNumberOfNames(GetAllPictureNames().Last().ID);
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
        public static void AddPicture(string picName)
        {
            CheckForConnection();
            int newID = GetNumberOfNames() + 1;

            NamesValues stuffToInput = new NamesValues { ID = newID, name = picName };

            InsertData("Names/" + stuffToInput.ID, stuffToInput);
            SetNumberOfNames(newID);
        }
    }
    public class NamesValues
    {
        public string name;
        public int ID;
    }
}