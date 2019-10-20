using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BoilerPlay
{
    public partial class Personal_profile : System.Web.UI.Page
    {
        EcoHunt.Database.UserValues acc;
        protected void Page_Load(object sender, EventArgs e)
        {
            Error_Flag.Visible = false;
            Success.Visible = false;
            profileBtn.Enabled = false;

            if (!IsPostBack)
            {
                //Cookies.WriteCookie("10001", this.Response);
                string x = EcoHunt.Cookies.ReadCookie(this.Request, this.Response);
                if (String.IsNullOrWhiteSpace(x))
                    Response.Redirect("LoginPage.aspx");
                acc = EcoHunt.Database.FirebaseUsers.GetUser(x);
                

                Edit.Visible = true;
                SubmitChanges.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                Profile_Password1.Visible = false;
                Profile_Password.Visible = false;
                //Filling in textboxes
                ProfileName.Value = acc.Name;
                ProfileEmail.Value = acc.GroupID;
                Profile_Description.Value = acc.Points.ToString();
                //Making Readonly
                ProfileName.Attributes.Add("readonly", "readonly");
                ProfileEmail.Attributes.Add("readonly", "readonly");
                Profile_Description.Attributes.Add("readonly", "readonly");
                Profile_PhoneNumber.Attributes.Add("readonly", "readonly");
                Profile_Year.Attributes.Add("readonly", "readonly");
                Profile_Password.Attributes.Add("readonly", "readonly");
                Profile_Password1.Attributes.Add("readonly", "readonly");
            }
        }

        protected void Edit_ServerClick(object sender, EventArgs e)
        {
            Edit.Visible = false;
            SubmitChanges.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            Profile_Password1.Visible = true;
            Profile_Password.Visible = true;
            ProfileName.Attributes.Remove("readonly");
            ProfileEmail.Attributes.Remove("readonly");
            Profile_Description.Attributes.Remove("readonly");
            Profile_PhoneNumber.Attributes.Remove("readonly");
            Profile_Year.Attributes.Remove("readonly");
            Profile_Password.Attributes.Remove("readonly");
            Profile_Password1.Attributes.Remove("readonly");
        }
        
        protected void SubmitChanges_ServerClick(object sender, EventArgs e)
        {
            /*
            var acc = user;
            acc = user = EcoHunt.Database.FirebaseUsers.GetUser(EcoHunt.Cookies.ReadCookie(this.Request,this.Response));
            acc.Name = ProfileName.Value.ToString();
            Console.WriteLine(acc.Name);
            acc.Phone = Profile_PhoneNumber.Value.ToString();
            acc.Year = Database.HelloWorldQueryMethods.IntfromYear(Profile_Year.Value.ToString());
            acc.Desc = Profile_Description.Value.ToString();
            acc.Email = ProfileEmail.Value.ToString();
            if (Profile_Password.Value != null)
            {
                if (Profile_Password.Value.ToString().Equals(Profile_Password1.Value.ToString()))
                {
                    acc.Password = Profile_Password.Value.ToString();
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
            Database.HelloWorldQueryMethods.UpdateAccount(acc);
            Edit.Visible = true;
            SubmitChanges.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            Profile_Password1.Visible = false;
            Profile_Password.Visible = false;
            ProfileName.Attributes.Add("readonly", "readonly");
            ProfileEmail.Attributes.Add("readonly", "readonly");
            Profile_Description.Attributes.Add("readonly", "readonly");
            Profile_PhoneNumber.Attributes.Add("readonly", "readonly");
            Profile_Year.Attributes.Add("readonly", "readonly");
            Profile_Password.Attributes.Add("readonly", "readonly");
            Profile_Password1.Attributes.Add("readonly", "readonly");
            
        */
        }

        protected void profileBtn_Click(object sender, EventArgs e)
        {

        }

        protected void myEventBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx?myEvents=true");
        }

        protected void allEventsBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }

        protected void createEventBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create_Event.aspx");
        }

        protected void logOutBtn_Click(object sender, EventArgs e)
        {
            EcoHunt.Cookies.DeleteCookie(this.Request, this.Response);
            Response.Redirect("LoginPage.aspx");
        }
    }
}