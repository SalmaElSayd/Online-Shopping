<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="WebApplication1.UserLogin" %>

&nbsp;

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

<p>    Login</p>

        <div>
<asp:Label ID="lbl_username" runat="server" Text="Username: "></asp:Label>
    
        <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
    
        <br />
    
        <br />
        <asp:Label ID="lbl_password" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>
    
        <br />
    
            <asp:Button ID="login_btn" runat="server" Text="Login" onclick="login"/>
    
        <br />
             <asp:Label ID="Label1" runat="server" Text="Don't have an account? "></asp:Label>
        <br />
             <asp:Button ID="Button1" runat="server" Text="Register as a customer" onclick="GoRegCust"/>
        <br />
             <asp:Button ID="Reg1" runat="server" Text="Register as a vendor" onclick="GoRegVendor"/>

            </div>
    </form>
</body>
</html>
