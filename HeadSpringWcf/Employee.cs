using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace HeadSpringWcf
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string EmployeeID { get; set; }
        [DataMember]
        public string EmployeeJobTitle{ get; set; }
        [DataMember]
        public string EmployeeLocation { get; set; }
        [DataMember]
        public string EmployeeEmail { get; set; }
        [DataMember]
        public string EmployeePhoneNumber { get; set; }
        [DataMember]
        public int EmployeeRole { get; set; }
    }
}
