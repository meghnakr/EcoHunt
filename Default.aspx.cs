using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcoHunt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Database.FirebaseDatabase.AddPicture("First Test");
            //var allNames = Database.FirebaseDatabase.GetAllPictureNames();
            //Database.FirebaseDatabase.DeletePicture("First Test");

            //string url = Database.FirebaseCloudStorage.AddPhotoToStorage(MapPath(@"~\milky-way.jpg"));
            //bool succeeded = Database.FirebaseCloudStorage.DeletePhotoFromStorage("milky-way.jpg");

            //ThreadStart ts = new ThreadStart(SendThingToTransfer);
            //Thread t = new Thread(ts);
            //t.Start();

            //Database.FirebaseDatabase.AddUrlsToPicturesWithoutUrls();
            //Database.FirebaseDatabase.TransferNameToGarbageFoundCategory("milky-way");
            //Database.FirebaseUsers.CreateUser("Kade0", "abc");
            //Database.FirebaseUsers.AddBrandNewGroupToUser("Kade0");
            //Database.FirebaseUsers.AddGroupToUser("Kade1", "h2e51mc5");

            var allPicturesWithGarbage = Database.FirebaseDatabase.GetAllPictureWithGarbageNames();
            DisplayPics(allPicturesWithGarbage);
            
        }
        private void DisplayPics(Database.NamesValues[] pictures)
        {
            for (int x = 0; x < pictures.Length; x++)
            {
                string url = pictures[x].url;
                StringBuilder text = new StringBuilder();

                text.Append("<div class=\"card\">");
                    text.Append("<div class=\"card bg-primary text-white\">");
                        text.Append("<b>" + "Picture" + "</b>");
                    text.Append("</div>");

                    text.Append("<div class=\"card-body\">");
                        text.Append("<a href=\"" + url + "\" >");
                            text.Append("<img width=\"100%\" src=\"" + url + "\" />");
                        text.Append("</a>");
                    text.Append("</div>");
                text.AppendLine("</div>");


                text.AppendLine("<br />");

                imgList.Text += text.ToString();
            }
        }
        private void SendThingToTransfer()
        {
            Thread.Sleep(2000);
            Database.FirebaseDatabase.TransferNameToGarbageFoundCategory("Planet");
        }
    }
}