<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="EcoHunt.LoginPage" %>

<!DOCTYPE html>
 <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
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
                    <form class="form-horizontal" id="login_form" role="form" runat="server">
                        <div class="form-group m-5">
                            <input type="text" class="form-control bg-light" runat="server" id="email" name="email" placeholder="Email ID" value="" required>
                        </div>
                        <div class="form-group m-5">
                            <input type="password" class="form-control bg-light" runat="server" id="Password" placeholder="Password" required>
                        </div>
                        <div style ="width:100%" class="text-center pb-n2">
                            <div class ="alert alert-danger text-center px-5 mx-5 pb-n2" runat="server" role="alert" id="Error_Flag" >
                                <p class="pb-n2">Incorrect Username or Password</p>
                            </div>
                        </div>
                        <div class="form-group text-center">
                           <!-- <input id="Login" name="submit" type="submit" value="LOGIN" class="btn btn-dark"> -->
                            <button class="btn btn-dark" id="Login" runat="server" onServerClick="Login_Click">LOGIN</button>
                        </div>
                        <p class="text-center">Don't have an account?</p>
                        <div class="form-group text-center">
                             <button class="btn btn-dark" id="Sign_Up" runat="server" onServerClick="Sign_Up_ServerClick">SIGN UP</button>
                        </div>

                     </form>
                 </div>
            </div>
        </div>
    </div>
</body>
</html>
