<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsletterSignup.aspx.cs" Inherits="NewsletterSignup"  ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Newsletter Signup!</h1>
            <p>
                <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
            </p>
        </div>
        <asp:Label ID="lblEmail" runat="server" Text="Enter Email:"  ViewStateMode="Disabled"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
    </form>
</body>
</html>
