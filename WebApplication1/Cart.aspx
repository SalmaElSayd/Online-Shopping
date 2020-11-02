<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebApplication1.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                    <asp:label ID ="title" runat="server" Text ="My cart" ></asp:label> 
       <br />     <asp:button ID="backhome" runat="server" Text ="Go back to home" OnClick ="GOback"></asp:button>

            <br /> <br />  <br /> 
                    <br />
                    <asp:TextBox ID="txtMessages" runat="server" Width="500"></asp:TextBox>
                    <br />
 <br /><asp:label ID ="add2cart_lbl" runat="server" Text  ="enter ptoduct serialnumber  " ></asp:label>  <br />
                    <asp:textbox ID ="add_txt" runat="server"  ></asp:textbox>  <br />
                    <asp:button ID ="add_btn" runat="server" Text  ="Add to cart" OnClick ="AddCart"></asp:button>

             <br /> <br />  <br /> <br />

             <asp:label ID ="remove4cart_lbl" runat="server" Text  ="enter ptoduct serialnumber  " ></asp:label>  <br />
                    <asp:textbox ID ="rem_txt" runat="server"  ></asp:textbox>  <br />
                    <asp:button ID ="rem_btn" runat="server" Text  ="Remove from cart" OnClick ="RemoveCart"></asp:button>
                     <br /> <br />  <br /> <br />
</div>
    </form>
</body>
</html>
