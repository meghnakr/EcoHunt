using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcoHunt.Database
{
    /// <summary>
    /// This class is meant to be inherited by other classes making use of its methods.
    /// This contains methods that are used to directly manipulate the data in the database
    /// </summary>
    public class DatabaseQueries
    {
        protected static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = API_Keys.firebaseAuthSecret,
            BasePath = API_Keys.firebaseBasePath
        };

        protected static IFirebaseClient client;

        public static bool IsClientConnected = false;

        /// <summary>
        /// This creates the connection to the Firebase Database
        /// It returns true if it succeeds
        /// </summary>
        /// <returns></returns>
        public static bool ConnectToDataBase()
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                IsClientConnected = true;
            }
            else
            {
                //OH CRAP!!
                IsClientConnected = false;
            }
            return IsClientConnected;
        }


        protected static void CheckForConnection()
        {
            if (IsClientConnected)
                return;
            else
            {
                bool didSucceed = ConnectToDataBase();
                if (!didSucceed)
                    throw new Exception("Client is not connected. Attempted: Could not connect.");
            }
        }

        protected static FirebaseResponse UpdateData(string path, object data)
        {
            FirebaseResponse response = client.Update(path, data);
            return response;
        }
        protected static void DeleteData(string path)
        {
            FirebaseResponse response = client.Delete(path);
        }
        protected static FirebaseResponse GetData(string path)
        {
            FirebaseResponse response = client.Get(path);
            return response;
        }
        protected static SetResponse InsertData(string path, object item)
        {
            SetResponse response = client.Set(path, item);
            return response;
        }
    }
}