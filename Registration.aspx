<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="EcoHunt.Registration" %>

<!DOCTYPE html>
 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
</head>
<body>
    <div class="row m-5">
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <div class="card">
                <div class="card-body">
                    <div class="card-header container-fluid bg-dark text-white">
                        <h2 class="text-center">EcoHunt</h2>
                    </div>
                    <form class="form-horizontal" id="registration_form" role="form" runat="server">
                        <div class="form-group m-3">
                            <input type="text" class="form-control bg-light"  runat="server" id="Name" name="name" placeholder="Name" value="" required>
                        </div>
                        <div class="form-group m-3">
                            <input type="password" class="form-control bg-light" runat="server" id="Password" placeholder="Password">
                        </div>
                        <div class="form-group m-3">
                            <input type="password" class="form-control bg-light" runat="server" id="Password1" placeholder="Re-enter Password">
                        </div>
                        <div style ="width:100%" class="text-center pb-n2">
                            <div class ="alert alert-danger text-center px-5 mx-5 pb-n2" runat="server" role="alert" id="Error_Flag" >
                            </div>
                        </div>
                        <div class="form-group text-center">
                            <button class="btn btn-dark" id="Register" runat="server" onServerClick="Register_ServerClick">SIGN UP</button>
                        </div>
                     </form>
                 </div>
            </div>
        </div>
    </div>
</body>
</html>
