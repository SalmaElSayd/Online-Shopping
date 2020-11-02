<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCreditCard.aspx.cs" Inherits="WebApplication1.AddCreditCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                    <asp:label ID="cardnum_lbl" runat="server" Text ="card number"></asp:label>
             <asp:TextBox ID="txt_num" runat="server"></asp:TextBox>
    
        <br />
                    <asp:label ID="exp_lbl" runat="server" Text ="expiry date"></asp:label>
             <asp:TextBox ID="txt_exp" runat="server"></asp:TextBox>
    
        <br /> 
                    <asp:label ID="ccv_lbl" runat="server" Text ="ccv number"></asp:label>
             <asp:TextBox ID="txt_ccv" runat="server"></asp:TextBox>
    
        <br />
                    <asp:button ID="AddCard_btn" runat="server" Text ="Add credit card" OnClick ="AddCard"></asp:button>
                                   <br />          
  <asp:TextBox ID="txtMessages" runat="server" Width="500"></asp:TextBox>
            <br />     <asp:button ID="backhome" runat="server" Text ="Go back to home" OnClick ="GOback"></asp:button>
        </div>
    </form>
</body>

</html>
