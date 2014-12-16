<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HeadSpringApp.WebForm1" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
           <asp:UpdatePanel runat="server" id="UpdatePanel" onload="Page_Load">
        <Triggers>
        </Triggers>
             
           <ContentTemplate>
    <div>

        <asp:Button ID="btnSearch" runat="server" Text="Search"  OnClick="btnSearch_Click"  />
          <td><asp:Label ID="Label1" Text="Enter Employee Name:" runat="server"/></td>
       <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnAdd" runat="server" Text="Add"  OnClick="btnAdd_Click" Enabled = "false" />
        <asp:Button ID="btnSave" runat="server" Text="Save Updates" OnClick="btnSave_Click" Enabled = "false" />

  <table align="Left">
  <tr>
  <td><asp:Label Text="Employee Name" runat="server"/></td>
  <td><asp:TextBox ID="txtName" runat="server" Enabled = "false"/></td>
  </tr>
    <tr>
      <td><asp:Label Text="Job Title" runat="server"/></td>
    <td><asp:TextBox ID="txtTitle" runat="server"  Enabled = "false"/></td>
  </tr>
    <tr>
        <td><asp:Label Text="Location" runat="server"/></td>
    <td><asp:TextBox ID="txtLocation" runat="server"  Enabled = "false"/></td>
  </tr>
    <tr>
    <td><asp:Label Text="Phone Number" runat="server"/></td>
    <td>   <asp:TextBox ID="txtPhoneNumber" runat="server"  Enabled = "false"/></td>
  </tr>
     <tr>
     <td><asp:Label  Text="Email" runat="server"/></td>
    <td><asp:TextBox ID="txtEmail" runat="server"  Enabled = "false"/></td>
  </tr>
   <tr>
    <td><asp:Label  Text="Employee Id" runat="server"/></td>
    <td><asp:TextBox ID="txtEmpId" runat="server" Enabled="false"/></td>
  </tr>
  <tr>
    <td><asp:Label Text="Employee Role" runat="server"/></td>
     <td> <asp:DropDownList ID="roleList" runat="server" Enabled = "false">
      <asp:ListItem Selected="True" Value="0"> HR </asp:ListItem>
       <asp:ListItem Value="1"> Employee </asp:ListItem>
      </asp:DropDownList>
    </td>
  </tr>
     <tr>
    <td><asp:Label Text="User Name" runat="server"/></td>
    <td><asp:TextBox ID="txtUserName" runat="server" Enabled = "false"/></td>
  </tr>
    <tr>
    <td><asp:Label Text="Password" runat="server"/></td>
    <td><asp:TextBox ID="txtPassword" runat="server" Enabled = "false"/></td>
  </tr> 
</table>

       <asp:DataGrid id="dataGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           AutoGenerateColumns="false"
           OnEditCommand="Grid_EditCommand"
           OnDeleteCommand="Grid_DeleteCommand"
           runat="server" AlternatingItemStyle-BackColor="Silver">
           <Columns>
           <asp:BoundColumn DataField="EmpName" HeaderText="Employee Name">
            </asp:BoundColumn>
                  <asp:BoundColumn DataField="EmpLocation" HeaderText="Employee Location">
            </asp:BoundColumn>
           <asp:BoundColumn DataField="EmpJobTitle" HeaderText="Employee JobTitle">
            </asp:BoundColumn>
             <asp:BoundColumn DataField="EmpEmail" HeaderText="Employee Email">
            </asp:BoundColumn>
           <asp:BoundColumn DataField="EmpPhone" HeaderText="Employee PhoneNumber">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="Role" HeaderText="Role">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="UserName" HeaderText="User Name">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="Pass" HeaderText="Pass">
            </asp:BoundColumn>
            <asp:BoundColumn DataField="EmpID" HeaderText="Employee ID">
            </asp:BoundColumn>
         <asp:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" HeaderText="Edit">
            </asp:EditCommandColumn>
           <asp:ButtonColumn CommandName="Delete" HeaderText="Delete" Text="Delete">
            </asp:ButtonColumn>
           </Columns>

      </asp:DataGrid>

    </div>
     </ContentTemplate>
       </asp:UpdatePanel>
    </form>
</body>
</html>
