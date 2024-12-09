<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication8.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Your Website Title</title>
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="pragma" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <!-- Other head elements... -->
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="GreetingLabel" runat="server"></asp:Label>
        <br />
        <asp:Label ID="ErrorMessageLabel" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Label ID="UsernameLabel" runat="server" Text="Username:"></asp:Label>
        <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="PasswordLabel" runat="server" Text="Password:"></asp:Label>
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString3 %>" 
            SelectCommand="SELECT [ID], [User_id], [PlainTextPassword] FROM [user_data]" ProviderName="<%$ ConnectionStrings:ConnectionString3.ProviderName %>">
        </asp:SqlDataSource>
    </form>
</body>
</html>