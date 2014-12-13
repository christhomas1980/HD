using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HeadSpringWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IHeadSpringService" in both code and config file together.
    [ServiceContract]
    public interface IHeadSpringService
    {
        [OperationContract]
        List<Employee> GetEmployee(List<Employee> getEmployeeList);

        [OperationContract]
        void DeleteEmployee(List<Employee> deleteEmployees);

        [OperationContract]
        void AddEmployee(List<Employee> addEmployees);

        [OperationContract]
        void UpdateEmployee(List<Employee> updateEmployees);

    }
}
