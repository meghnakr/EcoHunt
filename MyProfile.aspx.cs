using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcoHunt
{
    public partial class MyProfile : System.Web.UI.Page
    {
        string nameinp;
        EcoHunt.Database.UserValues user;
        protected void Page_Load(object sender, EventArgs e)
        {
            Error_Flag.Visible = false;
            Success.Visible = false;
            
            if (!IsPostBack)
            {
                nameinp = EcoHunt.Cookies.ReadCookie(this.Request, this.Response);
                if (String.IsNullOrWhiteSpace(nameinp))
                    Response.Redirect("LoginPage.aspx");
                user = EcoHunt.Database.FirebaseUsers.GetUser(nameinp);
                Edit.Visible = true;
                SubmitChanges.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                Profile_Password.Visible = false;
                Profile_Password1.Visible = false;

                Email.Value = user.Name;
                Points.Value = user.Points.ToString();

                Email.Attributes.Add("readonly", "readonly");

            }

        }

        protected void SubmitChanges_ServerClick(object sender, EventArgs e)
        {
            nameinp = EcoHunt.Cookies.ReadCookie(this.Request, this.Response);
            if (String.IsNullOrWhiteSpace(nameinp))
                Response.Redirect("LoginPage.aspx");
            user = EcoHunt.Database.FirebaseUsers.GetUser(nameinp);
            user.Name = Email.Value.ToString();
            if (Profile_Password.Value != null)
            {
                if (Profile_Password.Value.ToString().Equals(Profile_Password1.Value.ToString()))
                {
                    user.Password = Profile_Password.Value.ToString();
                    Success.Visible = true;
                }
                else
                {
                    Error_Flag.Visible = true;
                }
            }
            else
            {
                Success.Visible = true;
            }
            EcoHunt.Database.DatabaseQueries.UpdateData("Users/" + user.ID, user);
            Edit.Visible = true;
            SubmitChanges.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            Profile_Password1.Visible = false;
            Profile_Password.Visible = false;
            Email.Attributes.Add("readonly", "readonly");

        }

        protected void Edit_ServerClick(object sender, EventArgs e)
        {
            Edit.Visible = false;
            SubmitChanges.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            Profile_Password.Visible = true;
            Profile_Password1.Visible = true;
            Email.Attributes.Remove("readonly");
        }
    }
}