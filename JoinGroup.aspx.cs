using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcoHunt
{
    public partial class JoinGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dangerAlert.Visible = false;
            successAlert.Visible = false;

            string userName = Cookies.ReadCookie(this.Request, this.Response);

            var user = Database.FirebaseUsers.GetUser(userName);
            if (String.IsNullOrWhiteSpace(user.GroupID))
            {
                mainJumbotron.Visible = true;
                secondaryJumbotron.Visible = false;
            }
            else
            {
                mainJumbotron.Visible = false;
                secondaryJumbotron.Visible = true;
            }
        }

        protected void joinGroupBtn_Click(object sender, EventArgs e)
        {
            dangerAlert.Visible = false;
            successAlert.Visible = false;

            string userName = Cookies.ReadCookie(this.Request, this.Response);


            string groupID = groupTextBox.Text;
            bool doesExist = Database.FirebaseUsers.DoesGroupIdExist(groupID);

            if(doesExist)
            {
                Database.FirebaseUsers.AddGroupToUser(userName, groupID);
                groupTextBox.Text = String.Empty;
                dangerAlert.Visible = false;
                successAlert.Visible = true;
            }
            else
            {
                dangerAlert.Visible = true;
                successAlert.Visible = false;
            }
        }

        protected void createNewGroupBtn_Click(object sender, EventArgs e)
        {
            string userName = Cookies.ReadCookie(this.Request, this.Response);

            Database.FirebaseUsers.AddBrandNewGroupToUser(userName);
            Response.Redirect("Leaderboard.aspx");
        }

        protected void leaveGroupBtn_Click(object sender, EventArgs e)
        {
            string userName = Cookies.ReadCookie(this.Request, this.Response);
            Database.FirebaseUsers.RemoveGroupFromUser(userName);
            Response.Redirect("JoinGroup.aspx");
        }
    }
}