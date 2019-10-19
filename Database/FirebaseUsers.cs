using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcoHunt.Database
{
    public class FirebaseUsers : DatabaseQueries
    {
        public static void AddPoints(string userName, int pointsToAdd)
        {
            var user = GetUser(userName);
            user.Points += pointsToAdd;

            UpdateData("Users/" + user.ID, user);
        }
        public static void SubtractPoints(string userName, int pointsToSubtract)
        {
            var user = GetUser(userName);
            user.Points -= pointsToSubtract;

            UpdateData("Users/" + user.ID, user);
        }
        public static void SetPoints(string userName, int pointsToSetTo)
        {
            var user = GetUser(userName);
            user.Points = pointsToSetTo;

            UpdateData("Users/" + user.ID, user);
        }
        public static bool VerifyLogin(string userName, string password)
        {
            var allUsers = GetAllUsers();
            for (int x = 0; x < allUsers.Length; x++)
            {
                if (allUsers[x].Name == userName && allUsers[x].Password == password)
                    return true;
            }
            return false;
        }
        public static void AddBrandNewGroupToUser(string userName)
        {
            string brandNewGroupID = RandomGroupIDGenerator.CreateNewGroupID();

            AddGroupToUser(userName, brandNewGroupID, false);
        }
        public static string[] GetAllGroupIDs()
        {
            var users = GetAllUsers();

            List<string> groupIDs = new List<string>();
            for(int x = 0; x < users.Length; x++)
            {
                if(!groupIDs.Contains(users[x].GroupID))
                {
                    groupIDs.Add(users[x].GroupID);
                }
            }
            return groupIDs.ToArray();
        }
        public static bool DoesGroupIdExist(string groupID)
        {
            var allGroups = GetAllGroupIDs();
            return allGroups.Contains(groupID) ? true : false; 
        }
        public static void RemoveGroupFromUser(string userName)
        {
            var user = GetUser(userName);
            user.GroupID = String.Empty;

            UpdateData("Users/" + user.ID, user);
        }
        public static bool AddGroupToUser(string userName, string groupID, bool doesGroupNeedToExist = true)
        {
            var user = GetUser(userName);

            if(user != null)
            {
                if (doesGroupNeedToExist)
                {
                    if (DoesGroupIdExist(groupID) == true)
                    {
                        user.GroupID = groupID;
                        UpdateData("Users/" + user.ID, user);
                        return true;
                    }
                }
                else
                {
                    user.GroupID = groupID;
                    UpdateData("Users/" + user.ID, user);
                    return true;
                }
            }
            return false;
        }
        public static void CreateUser(string name, string password)
        {
            var possibleUser = GetUser(name);
            if (possibleUser != null)
                throw new Exception();

            int newID = GetNumberOfUsers() + 1;

            var newUser = new UserValues { ID = newID, Name = name, Password = password };
            InsertData("Users/" + newID, newUser);
            SetNumberOfUsers(newID);
        }
        public static UserValues[] GetUsersInGroup(string groupID)
        {
            var allUsers = GetAllUsers();

            List<UserValues> output = new List<UserValues>();
            for (int x = 0; x < allUsers.Length; x++)
            {
                if (allUsers[x].GroupID == groupID)
                    output.Add(allUsers[x]);
            }
            return output.ToArray();
        }
        public static UserValues GetUser(string name)
        {
            var allUsers = GetAllUsers();
            for(int x = 0; x < allUsers.Length; x++)
            {
                if (allUsers[x].Name == name)
                    return allUsers[x];
            }
            return null;
        }
        public static UserValues[] GetAllUsers()
        {
            CheckForConnection();
            var response = GetData("Users");
            object json = JsonConvert.DeserializeObject(response.Body);
            if (json == null)
                return new UserValues[0];

            List<UserValues> values = new List<UserValues>();
            foreach (JToken item in ((JToken)(json)).Children())
            {
                var newPatchNote = item.ToObject<UserValues>();
                values.Add(newPatchNote);
            }

            for (int x = values.Count - 1; x >= 0; x--)
            {
                if (values[x] == null)
                    values.RemoveAt(x);
            }
            return values.ToArray();
        }
        public static int GetNumberOfUsers()
        {
            CheckForConnection();
            return Convert.ToInt32(client.Get("NumberOfUsers").Body);
        }
        private static void SetNumberOfUsers(int number)
        {
            CheckForConnection();
            InsertData("NumberOfUsers", number);
        }
    }
    public class UserValues
    {
        public string Name;
        public string Password;
        public int ID;
        public string GroupID;
        public int Points;
    }
}