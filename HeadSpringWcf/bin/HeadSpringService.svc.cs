using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.ServiceModel.Activation;
using System.Web.Script.Serialization;

namespace HeadSpringWcf
{

    public class HeadSpringService : IHeadSpringService
    {
        public List<Employee> GetEmployee(List<Employee> getEmployeeList)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"C:\Users\Mektrik\Desktop\HeadSpring\HeadSpring2.mdb;Persist Security Info=False;");
            connection.Open();

            OleDbCommand cmd = new OleDbCommand();
            if (getEmployeeList == null || getEmployeeList.Count == 0)
            {
                cmd = new OleDbCommand("select * from EmployeeData", connection);
            }
            else if (getEmployeeList != null || getEmployeeList.Count > 0)
            {
                string strEmployee = string.Empty;
                foreach (Employee e in getEmployeeList)
                {
                    strEmployee += e.EmployeeName + ",";
                }

                strEmployee = strEmployee.TrimEnd(',');
                cmd = new OleDbCommand("select * from EmployeeData where EmpName In (" + strEmployee + ")", connection);
            }

            List<Employee> employeeList = new List<Employee>();
            OleDbDataReader oledbReader = cmd.ExecuteReader();
            if (oledbReader.HasRows)
            {
                while (oledbReader.Read())
                {
                    Employee employeeRecord = new Employee();
                    employeeRecord.EmployeeName = (string)oledbReader["EmpName"];
                    employeeRecord.EmployeeLocation = (string)oledbReader["EmpLocation"];
                    employeeRecord.EmployeeJobTitle = (string)oledbReader["EmpJobTitle"];
                    employeeRecord.EmployeePhoneNumber = (string)oledbReader["EmpPhone"];
                    employeeRecord.EmployeeEmail = (string)oledbReader["EmpEmail"];
                    employeeList.Add(employeeRecord);
                }
            }
         
            //return (new JavaScriptSerializer().Serialize(employeeList));
            return employeeList;
        }

        public void AddEmployee(List<Employee> addEmployees)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"C:\Users\Mektrik\Desktop\HeadSpring\HeadSpring2.mdb;Persist Security Info=False;");
            connection.Open();

            foreach (Employee e in addEmployees)
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO EmployeeData (EmpName, EmpJobTitle, EmpLocation, EmpEmail, EmpPhone) VALUES" +
                                            "(@EmployeeName, @EmployeeJobTitle, @EmployeeLocation, @EmployeeEmail, @EmployeePhoneNumber)", connection);
                    cmd.Parameters.AddWithValue("@EmployeeName", e.EmployeeName);
                    cmd.Parameters.AddWithValue("@EmployeeJobTitle", e.EmployeeName);
                    cmd.Parameters.AddWithValue("@EmployeeLocation", e.EmployeeLocation);
                    cmd.Parameters.AddWithValue("@EmployeeEmail", e.EmployeeEmail);
                    cmd.Parameters.AddWithValue("@EmployeePhoneNumber", e.EmployeePhoneNumber);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    connection.Close();
                }
                finally
                {
                    connection.Close();
                    
                }
            }
        }

        public void UpdateEmployee(List<Employee> deleteEmployees)
        {

            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"C:\Users\Mektrik\Desktop\HeadSpring\HeadSpring2.mdb;Persist Security Info=False;");


            connection.Open();

            foreach (Employee e in deleteEmployees)
            {
                try
                {


                    OleDbCommand cmd = new OleDbCommand("UPDATE EmployeeData SET [EmpName]=@EmployeeName,[EmpLocation]=@EmployeeLocation, [EmpJobTitle]=@EmployeeJobTitle, ," +
                 "[EmpEmail]=@EmployeeEmail, [EmpPhone]=@EmployeePhoneNumber where [EmpName] = @EmployeeName", connection);
                    cmd.Parameters.AddWithValue("@EmployeeName", e.EmployeeName);
                    cmd.Parameters.AddWithValue("@EmployeeID", e.EmployeeID);
                    cmd.Parameters.AddWithValue("@EmployeeJobTitle", e.EmployeeJobTitle);
                    cmd.Parameters.AddWithValue("@EmployeeLocation", e.EmployeeLocation);
                    cmd.Parameters.AddWithValue("@EmployeeEmail", e.EmployeeEmail);
                    cmd.Parameters.AddWithValue("@EmployeePhoneNumber", e.EmployeePhoneNumber);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    connection.Close();
                }
                finally
                {
                    connection.Close();
                    
                }
            }

        }

        public void DeleteEmployee(List<Employee> deleteEmployees)
        {

            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"C:\Users\Mektrik\Desktop\HeadSpring\HeadSpring2.mdb;Persist Security Info=False;");


            connection.Open();

            foreach (Employee e in deleteEmployees)
            {
                try
                {


                    OleDbCommand cmd = new OleDbCommand("DELETE FROM EmployeeData Where [EmpName] = @EmployeeName", connection);
                    cmd.Parameters.AddWithValue("@EmployeeName", e.EmployeeName);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    connection.Close();
                }
                finally
                {
                    connection.Close();

                }
            }
        }
        
    }
}
