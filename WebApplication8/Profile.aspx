<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApplication8.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profile</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Welcome, <asp:Label ID="UsernameLabel" runat="server"></asp:Label>!</h2>
            <p>Your User ID is: <asp:Label ID="UserIDLabel" runat="server"></asp:Label></p>
        </div>
    </form>
</body>
</html>

