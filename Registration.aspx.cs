using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcoHunt
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Error_Flag.Visible = false;
        }
        protected void Register_ServerClick(object sender, EventArgs e)
        {
            if (Password.Value.ToString().Equals(Password1.Value.ToString()))
            {
                try
                {
                    string userName = Name.Value.ToString();
                    Database.FirebaseUsers.CreateUser(userName, Password.Value.ToString());

                    Cookies.WriteCookie(userName, this.Response);
                    Response.Redirect("JoinGroup.aspx");
                }
                catch
                {
                    Error_Flag.Visible = true;
                    Error_Flag.InnerText = "This username is already in use.";
                }
            }
            else
            {
                Error_Flag.Visible = true;
                Error_Flag.InnerText = "Passwords do not match.";
            }
        }
    }
}