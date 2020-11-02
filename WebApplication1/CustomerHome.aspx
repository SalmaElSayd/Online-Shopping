<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerHome.aspx.cs" Inherits="WebApplication1.CustomerHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                        <asp:Button ID="cart_btn" runat="server" Text="View my cart" onclick="GoCart" align ="right"/>
<br />
<br />
                        <asp:Button ID="wish_btn" runat="server" Text="View my Wishlists" onclick="GoWish" align ="right"/>
<br />
<br />
            <asp:Button ID="credit_btn" runat="server" Text="Add a new credit card" onclick="GoCredit" align ="right"/>
<br />
<br />
             <asp:Button ID="tel_btn" runat="server" Text="Add my telephone number" onclick="GoTel" align ="right"/>
<br />
<br />
                        <asp:Button ID="prod_btn" runat="server" Text="View Products" onclick="ViewProducts" align ="left"/>
<br />
        </div>
    </form>
</body>
</html>
