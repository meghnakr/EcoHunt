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
            //Database.FirebaseCloudStorage.AddPhotoToStorage(MapPath("ImageNames.txt"));
            //bool isGarbage = GetGarbage.CheckGarbage("https://firebasestorage.googleapis.com/v0/b/ecomake-de93b.appspot.com/o/Pictures%2Fmilky-way.jpg?alt=media&token=9fa46c36-1364-4b9d-bd7c-d3734b275525");
            //var allPicturesWithGarbage = Database.FirebaseDatabase.GetAllPictureWithGarbageNames();
            //DisplayPics(allPicturesWithGarbage);
            //Database.FirebaseCloudStorage.ClearImageNameFile(MapPath("ImageNames.txt"));
            //Database.FirebaseCloudStorage.CheckForNewFiles(MapPath("ImageNames.txt"));
            //string url = "https://firebasestorage.googleapis.com/v0/b/ecomake-de93b.appspot.com/o/Pictures%2FImageNames.txt?alt=media&token=15e491e9-5014-462d-ae48-a504f62e4edb";
            //string result = Database.FirebaseCloudStorage.GetImageNames(url);
            DisplayPics(Database.FirebaseDatabase.GetAllPictureNames());
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