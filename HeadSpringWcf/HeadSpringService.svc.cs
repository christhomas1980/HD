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
using System.Data;

namespace HeadSpringWcf
{

    public class HeadSpringService : IHeadSpringService
    {
        public List<Employee> EmployeeLogin(string LoginName, string Password)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"C:\Users\Mektrik\Desktop\HeadSpring\HeadSpring2.mdb;Persist Security Info=False;");
            List<Employee> employeeList = new List<Employee>();
            connection.Open();
                try
                {
                    OleDbCommand cmd = new OleDbCommand("Select * from EmployeeData where UserName = @LoginName and Password= @Password", connection);
                    cmd.Parameters.AddWithValue("@LoginName", LoginName);
                    cmd.Parameters.AddWithValue("@Password", Password);

                    OleDbDataReader oledbReader = cmd.ExecuteReader();
                    if (oledbReader.HasRows)
                    {
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
                                employeeRecord.EmployeeRole = (int)oledbReader["Role"];
                                employeeList.Add(employeeRecord);
                            }
                        }
                        return employeeList;
                    }
                    connection.Close();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    connection.Close();
                }

                return employeeList;
        }

        public DataSet GetEmployee(string EmployeeName)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"C:\Users\Mektrik\Desktop\HeadSpring\HeadSpring2.mdb;Persist Security Info=False;");
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                OleDbDataAdapter adapter = null;
                OleDbCommand cmd = new OleDbCommand();
             
                if (string.IsNullOrEmpty(EmployeeName))
                {
                    adapter = new OleDbDataAdapter("select * from EmployeeData", connection);
                    adapter.Fill(ds, "EmployeeData");
                }
                else
                {
                    string strEmployee = EmployeeName;
                    adapter = new OleDbDataAdapter("select * from EmployeeData where EmpName = @EmployeeName", connection);
                    OleDbParameter param = new OleDbParameter();
                    adapter.SelectCommand.Parameters.Add("@EmployeeName", OleDbType.VarChar, 40, "EmpName").Value = strEmployee;
                    adapter.Fill(ds, "EmployeeData");
                }
                connection.Close();
                connection.Dispose();

            }
            catch (Exception e)
            {
                connection.Close();
                connection.Dispose();
            }

            return ds;
        }

        public DataSet AddEmployee(DataSet employees)
        {
            string sqlQuery = "select * from EmployeeData where 0 = 1";
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"C:\Users\Mektrik\Desktop\HeadSpring\HeadSpring2.mdb;Persist Security Info=False;");
                    try
                    {
                        connection.Open();
                       
                        DataSet ds = new DataSet();
                        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlQuery, connection);
                        dataAdapter.Fill(employees);
                        OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(dataAdapter);
                        dataAdapter.InsertCommand = new OleDbCommand("INSERT INTO EmployeeData (EmpName,EmpLocation, EmpJobTitle, EmpEmail,EmpPhone,Role,UserName,Pass,EmpId) VALUES" +
                                                "(@EmployeeName,  @EmployeeLocation, @EmployeeJobTitle, @EmployeeEmail, @EmployeePhoneNumber,@Role,@UserName,@Pass,@EmployeeId)", connection);
                        dataAdapter.InsertCommand.Parameters.Add("@EmployeeName", OleDbType.VarChar, 50, "EmpName");
                        dataAdapter.InsertCommand.Parameters.Add("@EmployeeLocation", OleDbType.VarChar, 50, "EmpLocation");
                        dataAdapter.InsertCommand.Parameters.Add("@EmployeeJobTitle", OleDbType.VarChar, 50, "EmpJobTitle");
                        dataAdapter.InsertCommand.Parameters.Add("@EmployeeEmail", OleDbType.VarChar, 50, "EmpEmail");
                        dataAdapter.InsertCommand.Parameters.Add("@EmployeePhoneNumber", OleDbType.VarChar, 50, "EmpPhone");
                        dataAdapter.InsertCommand.Parameters.Add("@Role", OleDbType.Numeric, 2, "Role");
                        dataAdapter.InsertCommand.Parameters.Add("@UserName", OleDbType.VarChar, 50, "UserName");
                        dataAdapter.InsertCommand.Parameters.Add("@Pass", OleDbType.VarChar, 50, "Pass");
                        dataAdapter.InsertCommand.Parameters.Add("@EmployeeId", OleDbType.VarChar, 50, "EmpId");

                        cmdBuilder.GetInsertCommand();
                        dataAdapter.Update(employees, "EmployeeData");
                        employees.AcceptChanges();
                        connection.Close();
                        connection.Dispose();
                    }
                    catch (Exception e)
                    {
                        connection.Close();
                        connection.Dispose();
                    }

                    return employees;
        }

        public DataSet UpdateEmployee(DataSet updateEmployees)
        {
            string sqlQuery = "select * from EmployeeData where 0 = 1";
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"C:\Users\Mektrik\Desktop\HeadSpring\HeadSpring2.mdb;Persist Security Info=False;");
            try
            {
                connection.Open();

                DataSet ds = new DataSet();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlQuery, connection);
                dataAdapter.Fill(updateEmployees);
                OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(dataAdapter);
                dataAdapter.UpdateCommand = new OleDbCommand("UPDATE EmployeeData SET EmpName=@EmployeeName,EmpLocation=@EmployeeLocation, EmpJobTitle=@EmployeeJobTitle," +
                 "EmpEmail=@EmployeeEmail, EmpPhone=@EmployeePhoneNumber,Role=@Role, UserName=@UserName,Pass=@Pass where EmpID = @EmployeeId", connection);
                dataAdapter.UpdateCommand.Parameters.Add("@EmployeeName", OleDbType.VarChar, 50, "EmpName");
                dataAdapter.UpdateCommand.Parameters.Add("@EmployeeLocation", OleDbType.VarChar, 50, "EmpLocation");
                dataAdapter.UpdateCommand.Parameters.Add("@EmployeeJobTitle", OleDbType.VarChar, 50, "EmpJobTitle");
                dataAdapter.UpdateCommand.Parameters.Add("@EmployeeEmail", OleDbType.VarChar, 50, "EmpEmail");
                dataAdapter.UpdateCommand.Parameters.Add("@EmployeePhoneNumber", OleDbType.VarChar, 50, "EmpPhone");
                dataAdapter.UpdateCommand.Parameters.Add("@Role", OleDbType.Numeric, 2, "Role");
                dataAdapter.UpdateCommand.Parameters.Add("@UserName", OleDbType.VarChar, 50, "UserName");
                dataAdapter.UpdateCommand.Parameters.Add("@Pass", OleDbType.VarChar, 50, "Pass");
                dataAdapter.UpdateCommand.Parameters.Add("@EmployeeId", OleDbType.VarChar, 50, "EmpId");

                cmdBuilder.GetUpdateCommand();
                dataAdapter.Update(updateEmployees, "EmployeeData");
                updateEmployees.AcceptChanges();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception e)
            {
                connection.Close();
                connection.Dispose();
            }

            return updateEmployees;
        }

        public DataSet DeleteEmployee(DataSet deleteEmployees)
        {
            string sqlQuery = "select * from EmployeeData where 0 = 1";
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"C:\Users\Mektrik\Desktop\HeadSpring\HeadSpring2.mdb;Persist Security Info=False;");
            try
            {
                connection.Open();

                DataSet ds = new DataSet();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlQuery, connection);
                dataAdapter.Fill(deleteEmployees);
                OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(dataAdapter);
                dataAdapter.DeleteCommand = new OleDbCommand("DELETE FROM EmployeeData Where EmpId = @EmployeeID", connection);
                dataAdapter.DeleteCommand.Parameters.Add("@EmployeeID", OleDbType.VarChar, 50, "EmpId");
                cmdBuilder.GetDeleteCommand();
                dataAdapter.Update(deleteEmployees, "EmployeeData");
                deleteEmployees.AcceptChanges();
                connection.Close();
                connection.Dispose();
            }
            catch (Exception e)
            {
                connection.Close();
                connection.Dispose();
            }

            return deleteEmployees;
        }
        
    }
}
