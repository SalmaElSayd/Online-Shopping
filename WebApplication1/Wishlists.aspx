<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Wishlists.aspx.cs" Inherits="WebApplication1.Wishlists" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                                <asp:TextBox ID="title" runat="server" Text ="My Wishlists"></asp:TextBox>
              <br />     <asp:button ID="backhome" runat="server" Text ="Go back to home" OnClick ="GOback"></asp:button>

            <br /> <br />  <br /> 
                                <asp:TextBox ID="txtMessages" runat="server" Width="500"></asp:TextBox>
                                <br />
                                <br />
 <br /><asp:label ID ="add2WL_lbl" runat="server" Text  ="enter ptoduct serialnumber  " ></asp:label>  <br />
                    <asp:textbox ID ="prod_add_txt" runat="server"  ></asp:textbox>  <br />
                   <asp:label ID ="add_name_lbl" runat="server" Text  ="enter list name  " ></asp:label>  <br />
            <asp:textbox ID ="listname_add_txt" runat="server"  ></asp:textbox>  <br />
                    <asp:button ID ="add_btn" runat="server" Text  ="Add to wishlist" OnClick ="AddWL"></asp:button>

             <br /> <br />  <br /> <br />

             <asp:label ID ="remove4WL_lbl" runat="server" Text  ="enter ptoduct serialnumber  " ></asp:label>  <br />
                    <asp:textbox ID ="prod_rem_txt" runat="server"  ></asp:textbox>  <br />
                         <asp:label ID ="name_rem_lbl" runat="server" Text  ="enter list name  " ></asp:label>  <br />        
            <asp:textbox ID ="listname_rem_txt" runat="server"  ></asp:textbox>  <br /> 
                    <asp:button ID ="rem_btn" runat="server" Text  ="Remove from wishlist" OnClick ="RemoveWL"></asp:button>
                     <br /> <br />  <br /> <br />

            <asp:label ID ="Label1" runat="server" Text  ="Create new wishlist " ></asp:label>  <br />
                    <asp:label ID ="Label2" runat="server" Text  ="Wishlist name: " ></asp:label> <br />
                    <asp:textbox ID ="newname_txt" runat="server"  ></asp:textbox>  <br />
                    <asp:button ID ="Button1" runat="server" Text  ="Create" OnClick ="createWL"></asp:button>
                     <br /> <br />  <br /> <br />

            <asp:label ID ="Label3" runat="server" Text  ="Select a wishlist to view" ></asp:label>  <br />
                    <asp:label ID ="Label4" runat="server" Text  ="Wishlist name: " ></asp:label> <br />
                    <asp:textbox ID ="viewname_txt" runat="server"  ></asp:textbox>  <br />
                    <asp:button ID ="Button2" runat="server" Text  ="View" OnClick ="viewWL"></asp:button>
                     <br /> <br />  <br /> <br />

        </div>
    </form>
</body>
</html>
