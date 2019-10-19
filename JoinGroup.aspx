<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="JoinGroup.aspx.cs" Inherits="EcoHunt.JoinGroup" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="jumbotron">
        <div style="text-align:center">
            <asp:Label runat="server" Text="JOIN A GROUP" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        </div>
        <br />
        <br />
        <asp:Label runat="server" Text="Enter Group Code"></asp:Label>
        <asp:TextBox TextMode="SingleLine" runat="server" ID="groupTextBox"></asp:TextBox>
        <asp:Button runat="server" Text="Join Group" ID="joinGroupBtn" OnClick="joinGroupBtn_Click" />
        
        <br />

        <div class="alert alert-danger" runat="server" visible="false" id="dangerAlert" role="alert">
          That GroupID does not exist!
        </div>
        <div class="alert alert-success" runat="server" visible="false" id="successAlert" role="alert">
          Successfully joined!
        </div>

        <br />
        
        <asp:Label runat="server" Text="Or Create Your own Group"></asp:Label>
        <asp:Button runat="server" Text="Create Group" id="createNewGroupBtn" OnClick="createNewGroupBtn_Click"/>
    </div>
</asp:Content>