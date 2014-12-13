using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeadSpringApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public ServiceReference1.HeadSpringServiceClient HeadSpringService = new ServiceReference1.HeadSpringServiceClient();
        public List<ServiceReference1.Employee> EmployeeList = new List<ServiceReference1.Employee>();

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSearch.Click += new EventHandler(Button2_Click);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnSave.Click += new EventHandler(btnSave_Click);

        }

        void btnSave_Click(object sender, EventArgs e)
        {
            ServiceReference1.Employee emp = new ServiceReference1.Employee();
            emp.EmployeeName = this.txtName.Text;
            emp.EmployeeJobTitle = this.txtTitle.Text;
            emp.EmployeeLocation = this.txtLocation.Text;
            emp.EmployeePhoneNumber = this.txtPhoneNumber.Text;
            emp.EmployeeEmail = this.txtEmail.Text;
            EmployeeList.Add(emp);
            HeadSpringService.UpdateEmployee(EmployeeList.ToArray());
        }

        void btnAdd_Click(object sender, EventArgs e)
        {

            ServiceReference1.Employee emp = new ServiceReference1.Employee();
            emp.EmployeeName = this.txtName.Text;
            emp.EmployeeJobTitle = this.txtTitle.Text;
            emp.EmployeeLocation = this.txtLocation.Text;
            emp.EmployeePhoneNumber = this.txtPhoneNumber.Text;
            emp.EmployeeEmail = this.txtEmail.Text;
            EmployeeList.Add(emp);
            HeadSpringService.AddEmployee(EmployeeList.ToArray());
        }

        void Button2_Click(object sender, EventArgs e)
        {

            List<ServiceReference1.Employee> empList = HeadSpringService.GetEmployee(EmployeeList.ToArray()).ToList();
            this.dataGrid.DataSource = empList;
            this.dataGrid.DataBind();
        }
        protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            DataGridItem dataItem = dataGrid.Items[e.Item.ItemIndex];

                ServiceReference1.Employee emp = new ServiceReference1.Employee();

                emp.EmployeeID = Convert.ToInt32(dataItem.Cells[0].Text.ToString());
                emp.EmployeeName = dataItem.Cells[1].Text;
                emp.EmployeeJobTitle = dataItem.Cells[2].Text;
                emp.EmployeeLocation = dataItem.Cells[3].Text;
                emp.EmployeePhoneNumber = dataItem.Cells[4].Text;
                emp.EmployeeEmail = dataItem.Cells[5].Text;
                EmployeeList.Add(emp);

            HeadSpringService.DeleteEmployee(EmployeeList.ToArray());
        }

        protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            DataGridItem dataItem = dataGrid.Items[e.Item.ItemIndex];
            this.txtName.Text = dataItem.Cells[1].Text;
            this.txtTitle.Text = dataItem.Cells[2].Text;
            this.txtLocation.Text = dataItem.Cells[3].Text;
            this.txtPhoneNumber.Text = dataItem.Cells[4].Text;
            this.txtEmail.Text = dataItem.Cells[5].Text;
        }

    }

}