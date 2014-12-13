<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HeadSpringApp.WebForm1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
       <link rel="stylesheet" type="text/css" href="../../themes/default/easyui.css">
    <link rel="stylesheet" type="text/css" href="../../themes/icon.css">
    <link rel="stylesheet" type="text/css" href="../demo.css">
    <script type="text/javascript" src="../../jquery.min.js"></script>
    <script type="text/javascript" src="../../jquery.easyui.min.js"></script>
</head>
<body>
    
    <form id="form1" runat="server">
 
    <div>

        <asp:Button ID="btnSearch" runat="server" Text="Search" />
       <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnAdd" runat="server" Text="Add" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" />
        <asp:Button ID="btnSave" runat="server" Text="Save" />

  <table align="right">
  <tr>
  <td><asp:Label Text="Employee Name" runat="server"/></td>
  <td><asp:TextBox ID="txtName" runat="server"/></td>
  </tr>
    <tr>
      <td><asp:Label Text="Job Title" runat="server"/></td>
    <td>  <asp:TextBox ID="txtTitle" runat="server"/></td>
  </tr>
    <tr>
        <td><asp:Label Text="Location" runat="server"/></td>
    <td>   <asp:TextBox ID="txtLocation" runat="server"/></td>
  </tr>
    <tr>
    <td><asp:Label Text="Phone Number" runat="server"/></td>
    <td>   <asp:TextBox ID="txtPhoneNumber" runat="server"/></td>
  </tr>
     <tr>
     <td><asp:Label  Text="Email" runat="server"/></td>
    <td><asp:TextBox ID="txtEmail" runat="server"/></td>
  </tr>

</table>

       <asp:DataGrid id="dataGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="false"
          
           OnEditCommand="Grid_EditCommand"
           OnDeleteCommand="Grid_DeleteCommand"
           
           runat="server" AllowSorting="True" AllowPaging="True" AlternatingItemStyle-BackColor="Silver">
           <Columns>
                      <asp:BoundColumn DataField="EmployeeID" HeaderText="Employee ID">
</asp:BoundColumn>
           <asp:BoundColumn DataField="EmployeeName" HeaderText="Employee Name">
</asp:BoundColumn>
           <asp:BoundColumn DataField="EmployeeJobTitle" HeaderText="Employee JobTitle">
</asp:BoundColumn>
          <asp:BoundColumn DataField="EmployeeLocation" HeaderText="Employee Location">
</asp:BoundColumn>

          <asp:BoundColumn DataField="EmployeePhoneNumber" HeaderText="Employee PhoneNumber">
</asp:BoundColumn>
       <asp:BoundColumn DataField="EmployeeEmail" HeaderText="Employee Email">
</asp:BoundColumn>
<asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Edit">
</asp:EditCommandColumn>
<asp:ButtonColumn CommandName="Delete" HeaderText="Delete" Text="Delete">
</asp:ButtonColumn>
           </Columns>

      </asp:DataGrid>

    </div>
    
    </form>
</body>
</html>
