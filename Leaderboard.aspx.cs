using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EcoHunt
{
    public partial class Leaderboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Cookies.ReadCookie(this.Request, this.Response);

            var user = Database.FirebaseUsers.GetUser(userName);
            if (String.IsNullOrEmpty(user.GroupID))
            {
                primaryJumbotron.Visible = false;
                secondaryJumbotron.Visible = true;
                //Response.Redirect("JoinGroup.aspx");
            }
            else
            {

                primaryJumbotron.Visible = true;
                secondaryJumbotron.Visible = false;

                groupCodeLbl.Text = user.GroupID;


                var usersInGroup = Database.FirebaseUsers.GetUsersInGroup(user.GroupID);

                var sortedList = usersInGroup.OrderBy(si => si.Points).Reverse().ToArray();

                for (int x = 0; x < sortedList.Length; x++)
                {
                    string cardColor = "primary";

                    if (sortedList[x].Name == user.Name)
                        cardColor = "success";

                    StringBuilder text = new StringBuilder();

                    text.Append("<div class=\"card\">");
                    text.Append("<div class=\"card bg-" + cardColor + " text-white\">");
                    text.Append("<b>" + sortedList[x].Name + "</b>");
                    text.Append("</div>");

                    text.Append("<div class=\"card-body\">");
                    text.Append("<a>Points: " + sortedList[x].Points + "</a>");
                    text.Append("</div>");
                    text.AppendLine("</div>");

                    text.AppendLine("<br />");

                    leaderboardList.Text += text.ToString();
                }
            }
        }

        protected void linkBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("JoinGroup.aspx");
        }
    }
}