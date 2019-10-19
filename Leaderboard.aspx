<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Leaderboard.aspx.cs" Inherits="EcoHunt.Leaderboard" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="jumbotron">
        <asp:Label runat="server" Text="Invite your friends with this code:"></asp:Label>
        <asp:Label runat="server" id="groupCodeLbl" Font-Bold="true"></asp:Label>

        <br />
        <br />

        <asp:Literal runat="server" ID="leaderboardList"></asp:Literal>
    </div>
</asp:Content>