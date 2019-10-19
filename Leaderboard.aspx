<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Leaderboard.aspx.cs" Inherits="EcoHunt.Leaderboard" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="jumbotron" runat="server" id="primaryJumbotron">
        <asp:Label runat="server" Text="Leaderboard" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        <br />
        <br />

        <asp:Label runat="server" id="textGroupCode" Text="Invite your friends with this code:"></asp:Label>
        <asp:Label runat="server" id="groupCodeLbl" Font-Bold="true"></asp:Label>

        <br />
        <br />

        <asp:Literal runat="server" ID="leaderboardList"></asp:Literal>
    </div>
    
    <div class="jumbotron" runat="server" id="secondaryJumbotron">
        <asp:Label runat="server" Text="Leaderboard" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
        <br />
        <br />

        <asp:Label runat="server" Text="You have not joined a group yet"></asp:Label>
        <br />
        <br />
        <asp:Button runat="server" ID="linkBtn" Text="Join a Group" OnClick="linkBtn_Click"></asp:Button>
    </div>
</asp:Content>