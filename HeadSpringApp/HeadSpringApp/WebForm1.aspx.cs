using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HeadSpringApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private ServiceReference1.HeadSpringServiceClient headSpringService = new ServiceReference1.HeadSpringServiceClient();
        private List<ServiceReference1.Employee> employeeList = new List<ServiceReference1.Employee>();

        protected void Page_Load(object sender, EventArgs e)
        {
            int empRole = (int)(Session["EmpRole"]);
              
            if (empRole == 1)
            {
                btnAdd.Enabled = false;
                btnSave.Enabled = false;
                txtName.Enabled = false;
                txtLocation.Enabled = false;
                txtPassword.Enabled = false;
                txtTitle.Enabled = false;
                txtPhoneNumber.Enabled = false;
                txtUserName.Enabled = false;
                txtEmail.Enabled = false;
                roleList.Enabled = false;
                txtEmpId.Enabled = false;

                foreach (DataGridColumn c in dataGrid.Columns)
                {
                    if (c.HeaderText == "Delete" || c.HeaderText == "Edit" || c.HeaderText == "Employee ID" || c.HeaderText=="Role" ||c.HeaderText=="UserName" || c.HeaderText=="Pass")
                    {
                        c.Visible = false;
                    }
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.btnSave.Enabled = false;
            this.btnAdd.Enabled = true;
            DataSet ds = (DataSet)Session["EmployeeDataSet"];
            DataRow[] foundRows = ds.Tables["EmployeeData"].Select("EmpId ='" + txtEmpId.Text + "'");
            int rowIndex = ds.Tables["EmployeeData"].Rows.IndexOf(foundRows.FirstOrDefault());
            ds.Tables["EmployeeData"].Rows[rowIndex]["EmpName"] = this.txtName.Text;
            ds.Tables["EmployeeData"].Rows[rowIndex]["EmpJobTitle"] = this.txtTitle.Text;
            ds.Tables["EmployeeData"].Rows[rowIndex]["EmpLocation"] = this.txtLocation.Text;
            ds.Tables["EmployeeData"].Rows[rowIndex]["EmpPhone"] = this.txtPhoneNumber.Text;
            ds.Tables["EmployeeData"].Rows[rowIndex]["EmpEmail"] = this.txtEmail.Text;
            ds.Tables["EmployeeData"].Rows[rowIndex]["Role"] = Convert.ToInt32(this.roleList.SelectedValue);
            ds.Tables["EmployeeData"].Rows[rowIndex]["UserName"] = this.txtUserName.Text;
            ds.Tables["EmployeeData"].Rows[rowIndex]["Pass"] = this.txtPassword.Text;

            ds = headSpringService.UpdateEmployee(ds);
            this.dataGrid.DataSource = ds;
            this.dataGrid.DataBind();
            Session["EmployeeDataSet"] = ds;
            ClearTextBox();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ServiceReference1.Employee emp = new ServiceReference1.Employee();
            DataSet ds = (DataSet)Session["EmployeeDataSet"];
            DataRow newRow = ds.Tables["EmployeeData"].NewRow();
            newRow["EmpName"] = this.txtName.Text;
            newRow["EmpJobTitle"] = this.txtTitle.Text;
            newRow["EmpLocation"] = this.txtLocation.Text;
            newRow["EmpPhone"] = this.txtPhoneNumber.Text;
            newRow["EmpEmail"] = this.txtEmail.Text;
            newRow["Role"] = Convert.ToInt32(this.roleList.SelectedValue);
            newRow["UserName"] = this.txtUserName.Text;
            newRow["Pass"] = this.txtPassword.Text;
            newRow["EmpId"] = Guid.NewGuid().ToString();

            ds.Tables["EmployeeData"].Rows.Add(newRow);
            ds = headSpringService.AddEmployee(ds);
            this.dataGrid.DataSource = ds;
            this.dataGrid.DataBind();
            Session["EmployeeDataSet"] = ds;
            ClearTextBox();
        }

       protected void btnSearch_Click(object sender, EventArgs e)
        {
            int empRole = (int)(Session["EmpRole"]);

            if (empRole == 0)
            {
                btnAdd.Enabled = true;
                txtName.Enabled = true;
                txtLocation.Enabled = true;
                txtPassword.Enabled = true;
                txtTitle.Enabled = true;
                txtPhoneNumber.Enabled = true;
                txtUserName.Enabled = true;
                txtEmail.Enabled = true;
                roleList.Enabled = true;
            }
            DataSet ds = headSpringService.GetEmployee(txtSearch.Text);
   
            this.dataGrid.DataSource = ds;
            this.dataGrid.DataBind();
            Session["EmployeeDataSet"] = ds;
        }

       void ClearTextBox()
       {
           txtName.Text = "";
           txtLocation.Text = "";
           txtPassword.Text = "";
           txtTitle.Text = "";
           txtPhoneNumber.Text = "";
           txtUserName.Text = "";
           txtEmail.Text = "";
           txtPassword.Text = "";
       }

        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            DataSet ds = (DataSet)Session["EmployeeDataSet"];
            DataGridItem dataItem = dataGrid.Items[e.Item.ItemIndex];
            DataRow[] foundRows = ds.Tables["EmployeeData"].Select("EmpId ='" + dataItem.Cells[8].Text + "'");
            int rowIndex = ds.Tables["EmployeeData"].Rows.IndexOf(foundRows.FirstOrDefault());

            ds.Tables["EmployeeData"].Rows[rowIndex].Delete();

            ds = headSpringService.DeleteEmployee(ds);
            this.dataGrid.DataSource = ds;
            this.dataGrid.DataBind();
            Session["EmployeeDataSet"] = ds;
        }

        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            DataGridItem dataItem = dataGrid.Items[e.Item.ItemIndex];
            this.txtName.Text = dataItem.Cells[0].Text;
            this.txtTitle.Text = dataItem.Cells[2].Text;
            this.txtLocation.Text = dataItem.Cells[1].Text;
            this.txtPhoneNumber.Text = dataItem.Cells[4].Text;
            this.txtEmail.Text = dataItem.Cells[3].Text;
            this.txtEmpId.Text = dataItem.Cells[8].Text;
            this.roleList.SelectedValue = dataItem.Cells[5].Text;
            this.txtUserName.Text = dataItem.Cells[6].Text;
            this.txtPassword.Text = dataItem.Cells[7].Text;
            this.btnSave.Enabled  = true;
            this.btnAdd.Enabled = false;
        }
    }

}