<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HeadSpringLogin.aspx.cs" Inherits="HeadSpringApp.HeadSpringLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="position: fixed; top: 50%; left: 50%">
<table align="center">
  <tr>
  <td><asp:Label ID="Label1" Text="User Name" runat="server"/></td>
  <td> <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
  </tr>
    <tr>
      <td><asp:Label ID="Label2" Text="Password" runat="server"/></td>
    <td> <asp:TextBox ID="txtPassWord" runat="server" TextMode="Password"></asp:TextBox></td>
  </tr>
    <tr>
        <td><asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
  </tr>
</table>

    </div>
    </form>
</body>
</html>
