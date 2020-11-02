<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTelephone.aspx.cs" Inherits="WebApplication1.AddTelephone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                    <asp:label ID="tel_lbl" runat="server" Text ="telephone number"></asp:label>
             <asp:TextBox ID="txt_tel" runat="server"></asp:TextBox>
    
        <br />       <asp:TextBox ID="txtMessages" runat="server" Width="500px"></asp:TextBox>
                        <br />
                    <asp:button ID="AddTel_btn" runat="server" Text ="Add telephone number" OnClick ="AddPhone"></asp:button>
                             <br />     <asp:button ID="backhome" runat="server" Text ="Go back to home" OnClick ="GOback"></asp:button>

        </div>
    </form>
</body>
</html>
