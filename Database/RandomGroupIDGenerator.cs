using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EcoHunt.Database
{
    public class RandomGroupIDGenerator
    {
        public static string CreateNewGroupID()
        {
            string output = String.Empty;
            do
            {
                output = GenerateNewGroupID();
            } while (Database.FirebaseUsers.DoesGroupIdExist(output));

            return output;
        }
        private static string GenerateNewGroupID()
        {
            Random rand = new Random();
            string chars = "abcdefghijklmnopqrstuvwxyz1234567890";
            int lengthOfID = 8;

            StringBuilder output = new StringBuilder();

            for(int x = 0; x < lengthOfID; x++)
            {
                int index = rand.Next(0, chars.Length - 1);
                output.Append(chars[index]);
            }
            return output.ToString();
        }
    }
}