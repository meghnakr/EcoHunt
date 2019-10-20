<%@ Page Title="My Profile  " Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="EcoHunt.MyProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<body>
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
                            <div class="row">
                                <div class="col-6 col-md-6">
                                    <p class="text-left">Email: </p>
                                    <input type="email" id="Email" name="email" runat="server" class="form-control bg-light" required placeholder="Profile Email">
                                </div>
                                <div class="col-6 col-md-6">
                                    <p class="text-left">Points:</p>
                                    <input type="text" class="form-control bg-grey" runat="server" id="Points" name="points" required placeholder="0" readonly>
                                </div>
                                <div class="col-6 col-md-6">
                                    <p class="text-left mt-3" id="label1" runat="server">Enter Password:</p>
                                    <input type="password" class="form-control bg-light" runat="server" id="Profile_Password" placeholder="Leave blank to use old password">
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
    </body>
</asp:Content>
