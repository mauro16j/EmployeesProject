using Models;
using Models.Factory;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Utils
{
    public class EmployeeConverter : AbstractJsonConverter<Employee>
    {
        protected override Employee Create(Type objectType, JObject jObject)
        {
            int id = 0;
            string name = string.Empty;
            string contractTypeName = string.Empty;
            Role rol = new Role();
            decimal salary = 0;

            var employee = ValueFieldExists(jObject, "contractTypeName", JTokenType.String).First();
            id = Convert.ToInt32(employee.Key.GetValue("id"));
            name = employee.Key.GetValue("name").ToString();
            contractTypeName = employee.Key.GetValue("contractTypeName").ToString();
            rol.roleDescription = employee.Key.GetValue("roleDescription").ToString();
            rol.roleId = Convert.ToInt32(employee.Key.GetValue("roleId"));
            rol.roleName = employee.Key.GetValue("roleName").ToString();

            if (employee.Value == ContractTypeName.HourlySalaryEmployee.ToString())
            {
                salary = Convert.ToDecimal(employee.Key.GetValue("hourlySalary"));
                return new HourlyEmployee(id, name, contractTypeName, rol, salary);
            }
            else if (employee.Value == ContractTypeName.MonthlySalaryEmployee.ToString())
            {
                salary = Convert.ToDecimal(employee.Key.GetValue("monthlySalary")); 
                return new MonthlyEmployee(id, name, contractTypeName, rol, salary);
            }

            return null;
        }
    }
}
