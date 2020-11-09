using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MonthlyEmployee : Employee
    {
        private const int kMeses = 12;

        public MonthlyEmployee(int id, string name, string contractTypeName, Role role, decimal salary)
        {
            this.id = id;
            this.name = name;
            this.contractTypeName = contractTypeName;
            this.role = role;
            this.calculatedAnnualSalary = CalculateAnnualSalary(salary);
        }

        public override decimal CalculateAnnualSalary(decimal salary)
        {
            return salary * kMeses;
        }


    }
}
