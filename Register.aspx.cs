<%@ Page Language = "C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SyncMateWebForms.Register" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Register</h2>
            <label>Name:</ label >
            < asp:TextBox ID = "txtName" runat="server"></asp:TextBox >< br />
            < label > Email:</ label >
            < asp:TextBox ID = "txtEmail" runat="server"></asp:TextBox >< br />
            < label > Password:</ label >
            < asp:TextBox ID = "txtPassword" TextMode="Password" runat="server"></asp:TextBox >< br />
            < asp:Button ID = "btnRegister" Text="Register" OnClick="btnRegister_Click" runat="server" />
        </div>
    </form>
</body>
</html>
