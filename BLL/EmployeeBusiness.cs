using DAL;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Collections.Generic;
using Utils;
using System.Threading.Tasks;

namespace BLL
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        #region Metodos Publicos
        /// <summary>
        /// Lista todos los empleados del API
        /// </summary>
        /// <returns>Lista de elementos tipo Employee</returns>
        public async Task<List<Employee>> ListEmployees()
        {
            EmployeeData dal = new EmployeeData();
            string plainEmpleados = await dal.ListEmployee();
            List<Employee> lst_empleados = GetDeserializeObject(plainEmpleados);
            return lst_empleados;
        }

        /// <summary>
        /// Obtiene un empleado por su Id
        /// </summary>
        /// <param name="id">Id del empleado</param>
        /// <returns>elemento tipo Employee</returns>
        public async Task<Employee> GetEmployee(int id)
        {
            Employee employee = (await ListEmployees()).Where(x => x.id == id).FirstOrDefault();
            return employee;
        }

        #endregion

        #region Metodos Privados
        /// <summary>
        /// Obtiene la lista de empleados deserializando el JSON entregado en el response del API
        /// </summary>
        /// <param name="json">texto json</param>
        /// <returns>Lista de elementos tipo employee</returns>
        private List<Employee> GetDeserializeObject(string json)
        {
            var converter = new EmployeeConverter();
            var deserializedArray = JsonConvert.DeserializeObject<List<Employee>>(
                json,
                converter);

            return deserializedArray;
        }

        #endregion
    }
}
