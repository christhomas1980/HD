using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HeadSpringApp
{
    public partial class HeadSpringLogin : System.Web.UI.Page
    {
        ServiceReference1.HeadSpringServiceClient HeadSpringService = new ServiceReference1.HeadSpringServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnLogin.Click += new EventHandler(btnLogin_Click);

        }

        void btnLogin_Click(object sender, EventArgs e)
        {
            List<ServiceReference1.Employee> empList  = HeadSpringService.EmployeeLogin(txtUserName.Text, txtPassWord.Text).ToList();
            if (empList.Count == 1)
            {
                Session["EmpRole"] = empList.FirstOrDefault().EmployeeRole;
                Response.Redirect("WebForm1.aspx");
            }
            else
            {

            }
        }
    }
}