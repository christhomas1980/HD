using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace HeadSpringWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHeadSpringService" in both code and config file together.
    [ServiceContract]
    public interface IHeadSpringService
    {
        [OperationContract]
        DataSet GetEmployee(string EmployeeName);

        [OperationContract]
        DataSet DeleteEmployee(DataSet deleteEmployees);

        [OperationContract]
        DataSet AddEmployee(DataSet addEmployees);

        [OperationContract]
        DataSet UpdateEmployee(DataSet updateEmployees);

        [OperationContract]
        List<Employee> EmployeeLogin(string LoginName, string Password);

    }
}
