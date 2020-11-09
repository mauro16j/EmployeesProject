using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class HourlyEmployee : Employee
    {
        private const int kMeses = 12;
        private const int kHoras = 120;

        public HourlyEmployee(int id, string name, string contractTypeName, Role role, decimal salary)
        {
            this.id = id;
            this.name = name;
            this.contractTypeName = contractTypeName;
            this.role = role;
            this.calculatedAnnualSalary = CalculateAnnualSalary(salary);
        }

        public override decimal CalculateAnnualSalary(decimal salary)
        {
            return kHoras * salary * kMeses;
        }
    }
}
