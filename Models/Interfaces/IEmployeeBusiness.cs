using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IEmployeeBusiness
    {
        Task<List<Employee>> ListEmployees();
        Task<Employee> GetEmployee(int id);
    }
}
