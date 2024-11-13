using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstExample_WebApi.Models
{
    /// <summary>
    /// This class represents an Employee that transfers in the REST
    /// </summary>
    public class Employee//Entity generated class
    {
        public int ID { get; set; }
        public string EmpName { get; set; } = string.Empty;
        public string EmpAddress { get; set; } = string.Empty;
        public DateTime EmpDOJ { get; set; } = DateTime.Now;
        public Employee Assign(Employee temp)
        {
            EmpName = temp.EmpName;
            EmpAddress = temp.EmpAddress;
            EmpDOJ = temp.EmpDOJ;
            return this;
        }
    }
  
    public class EmpFinder
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
    }
}
