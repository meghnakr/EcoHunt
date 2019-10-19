using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


            //Database.FirebaseDatabase.AddUrlsToPicturesWithoutUrls();
            /*
            for (int x = 0; x < 10; x++)
            {
                string url = "";
                StringBuilder text = new StringBuilder();
                text.Append("<a href=\"" + url + "\" >");
                text.Append("<img width=\"200px\" src=\"" + url + "\" />");
                text.Append("</a>");

                imgList.Text += text.ToString();
            }
            */
        }
    }
}