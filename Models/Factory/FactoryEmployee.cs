using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Factory
{
    public class FactoryEmployee
    {
        public static Employee Create(int id, string name, ContractTypeName contractTypeName, Role role, decimal salary)
        {
            switch (contractTypeName)
            {
                case ContractTypeName.HourlySalaryEmployee:
                    return new HourlyEmployee(id, name, ContractTypeName.HourlySalaryEmployee.ToString(), role, salary);

                case ContractTypeName.MonthlySalaryEmployee:
                    return new MonthlyEmployee(id, name, ContractTypeName.MonthlySalaryEmployee.ToString(), role, salary);
                default:
                    return null;
            }
        }
    }
}
