<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personal_profile.aspx.cs" Inherits="BoilerPlay.Personal_profile" %>

<!DOCTYPE html>
<link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet">
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
</head>
<body>
    
    <form runat="server">
    <div class="container-fluid bg-dark text-white pt-5">
        <div class="row mb-5">
            <div class="col-md-4 mb-5"></div>
            <div class="col-md-4 col-12">
                <h1 class="text-center">BoilerPlay</h1>
                <p class="text-center">Find teammates anytime, anywhere!</p>
                <div class="row text3center">
                    <div class="col-3 col-md-3"><asp:Button runat="server" CssClass="btn btn-light mb-5" ID="createEventBtn" style="font-size: 11.9px; font-weight: bold" OnClick="createEventBtn_Click" Text="Create Event" /></div>                 
                    <div class="col-3 col-md-3"><asp:Button runat="server" CssClass="btn btn-light mb-5" ID="allEventsBtn" style="font-size: 11.9px; font-weight: bold" OnClick="allEventsBtn_Click" Text="All Events" /></div>               
                    <div class="col-3 col-md-3"><asp:Button runat="server" CssClass="btn btn-light mb-5" ID="myEventBtn" style="font-size: 11.9px; font-weight: bold" OnClick="myEventBtn_Click" Text="My Events" /></div>
                    <div class="col-3 col-md-3"><asp:Button runat="server" CssClass="btn btn-light mb-5" ID="profileBtn" style="font-size: 11.9px; font-weight: bold" OnClick="profileBtn_Click" Text="Profile" /></div>
                </div>                       
             </div>
        </div>
    </div>
    <div class="col-md-5"></div>
    <div style="text-align:right;margin-right:20px;margin-top:0px">
        <asp:Button runat="server" CssClass="btn btn-secondary mb-5" ID="logOutBtn" style="font-size: 11.9px; font-weight: bold" OnClick="logOutBtn_Click" Text="Log Out" />
    </div>



    <div class="container">
       <div class="row pt-5 text-center">
           <div class="col-md-1"></div>
           <div class="col-md-10 col-10">
              <div class="card">
                <div class="card-body">
                    <form class="form-horizontal" role="form">
                        <div class="row">
                            <div class="col-4 col-md-4"></div>
                            <div class="col-4 col-md-4">
                                <h2>Your Profile</h2>
                            </div>
                            <div class="col-4 col-md-4 text-right pr-4">
                                <button class="btn btn-dark" id="Edit" runat="server" onserverclick="Edit_ServerClick">Edit</button>
                            </div>
                        </div>
                        <div style ="width:100%" class="text-center pb-n2">
                            <div class ="alert alert-danger text-center px-5 mx-5 pb-n2" runat="server" role="alert" id="Error_Flag" >
                                <p class="pb-n2">Passwords do not match</p>
                            </div>
                            <div class ="alert alert-success text-center px-5 mx-5 pb-n2" runat="server" role="alert" id="Success" >
                                <p class="pb-n2">Details Updated!</p>
                            </div>
                        </div>
                        <div class="form-group m-3">
                            <input type="text" class="form-control bg-light" runat="server" id="ProfileName" name="name" placeholder="Profile_Name" value="" required>
                        </div>
                        <div class="form-group m-3">
                            <input type="email" class="form-control bg-light" runat="server" id="ProfileEmail" name="email" placeholder="Profile_Email" value="" required>
                        </div>
                        <div class="form-group m-3">
                            <input type="text" class="form-control bg-light" runat="server" id="Profile_Description" name="description" placeholder="Profile_Description" value="" required>
                        </div>
                        <div class="form-group m-3">
                            <div class="row">
                                <div class="col-6 col-md-6">
                                    <p class="text-left">Phone number: </p>
                                    <input type="tel" id="Profile_PhoneNumber" name="phone" maxlength="10" runat="server" pattern="[0-9]{10}" class="form-control bg-light" required placeholder="Profile_PhoneNumber">
                                </div>
                                <div class="col-6 col-md-6">
                                    <p class="text-left">Year:</p>
                                    <input type="text" class="form-control bg-light" runat="server" id="Profile_Year" name="year" placeholder="Profile_Year" value="" required>
                                </div>
                                <div class="col-6 col-md-6">
                                    <p class="text-left mt-3" id="label1" runat="server">Enter Password:</p>
                                    <input type="password" class="form-control bg-light" runat="server" id="Profile_Password" placeholder="Leave Blank to use old password">
                                </div>
                                <div class="col-6 col-md-6">
                                    <p class="text-left mt-3" id="label2" runat="server">Re-enter Password:</p>
                                    <input type="password" class="form-control bg-light" runat="server" id="Profile_Password1" placeholder="">
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 col-md-12 text-right pr-4">
                                <button class="btn btn-dark" id="SubmitChanges" runat="server" onserverclick="SubmitChanges_ServerClick">Submit</button>
                            </div>
                        </div>
                     </form>
                 </div>
            </div>
           </div>
       </div>
    </div>
        </form>
</body>
</html>
