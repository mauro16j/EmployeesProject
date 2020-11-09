using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public abstract class Employee
    {
        public abstract decimal CalculateAnnualSalary(decimal salary);

        public int id { get; set; }
        public string name { get; set; }
        public string contractTypeName { get; set; }
        public Role role { get; set; }
        public decimal calculatedAnnualSalary { get; set; }
    }
}
