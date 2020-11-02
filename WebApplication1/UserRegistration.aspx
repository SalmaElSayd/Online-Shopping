<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="WebApplication1.UserRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Customer Registration<div>
            <br />
            <asp:TextBox ID="txtMessages" runat="server" Width="500px"></asp:TextBox>
                        <br />

              <asp:Label ID="lbl_username" runat="server" Text="Username: "></asp:Label>
                <asp:TextBox ID="usr" runat="server"></asp:TextBox><br />

               <asp:Label ID="lbl_firstname" runat="server" Text="First name: "></asp:Label>
               <asp:TextBox ID="fn" runat="server"></asp:TextBox> <br />

              <asp:Label ID="lbl_lastname" runat="server" Text="Last name: "></asp:Label>
               <asp:TextBox ID="ln" runat="server"></asp:TextBox> <br />

             <asp:Label ID="lbl_password" runat="server" Text="Password: "></asp:Label>
             <asp:TextBox ID="pass" runat="server" TextMode="Password"></asp:TextBox><br />

             <asp:Label ID="lbl_email" runat="server" Text="Email: "></asp:Label>
               <asp:TextBox ID="eml" runat="server"></asp:TextBox> <br />
           
            <br />

           <asp:Button ID="Button1" runat="server" Text="Register" onclick="CustomerReg" />
                        <br />
        
            <asp:Button ID="back" runat="server" Text="Go back to login page" onclick="GOback" />

        </div>
    </form>
</body>
</html>
