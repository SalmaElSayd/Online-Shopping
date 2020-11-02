<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendorRegistration.aspx.cs" Inherits="WebApplication1.VendorRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
              Vendor Registration
            <br />
                         <asp:TextBox ID="txtMessages" runat="server" Width="500px"></asp:TextBox>
                        <br />


              <asp:Label ID="lbl_username" runat="server" Text="Username: "></asp:Label>
                <asp:TextBox ID="usr" runat="server"></asp:TextBox> <br />


               <asp:Label ID="lbl_firstname" runat="server" Text="First name: "></asp:Label>
                <asp:TextBox ID="fn" runat="server"></asp:TextBox> <br />

              <asp:Label ID="lbl_lastname" runat="server" Text="Last name: "></asp:Label>
                <asp:TextBox ID="ln" runat="server"></asp:TextBox> <br />

             <asp:Label ID="lbl_password" runat="server" Text="Password: "></asp:Label>
                 <asp:TextBox ID="pass" runat="server" TextMode="Password"></asp:TextBox><br />

             <asp:Label ID="lbl_email" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="eml" runat="server"></asp:TextBox> <br />
           
             <asp:Label ID="lbl_company_name" runat="server" Text="Company name: "></asp:Label>
                <asp:TextBox ID="company_name_text" runat="server"></asp:TextBox> <br />

             <asp:Label ID="lbl_bank_acc_no" runat="server" Text="Bank account number: "></asp:Label>
               <asp:TextBox ID="bank_account_text" runat="server"></asp:TextBox> <br />
            <br />
                             <asp:Button ID="Register" runat="server" Text="Register" onclick="VendorReg" />
                            <br />           
                  <asp:Button ID="back" runat="server" Text="Go back to login page" onclick="GOback" />

        </div>
        </div>
    </form>
</body>
</html>
