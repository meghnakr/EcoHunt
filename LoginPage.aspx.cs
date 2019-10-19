using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcoHunt
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Error_Flag.Visible = false;
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            String inEmail = email.Value.ToString();
            String inPass = Password.Value.ToString();
            if (inEmail != null && inPass != null)
            {
                if (Database.FirebaseUsers.VerifyLogin(inEmail, inPass))
                {
                    Cookies.WriteCookie(inEmail, this.Response);
                    Response.Redirect("Leaderboard.aspx");
                }
                else
                {
                    Error_Flag.Visible = true;
                }

            }
        }

        protected void Sign_Up_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }
    }
}