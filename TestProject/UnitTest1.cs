using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BusinessListEmployees()
        {
            var objBusiness = new EmployeeBusiness();
            var listEmployees = new List<Employee>();
            Task.Run(async () =>
            {
                listEmployees = await objBusiness.ListEmployees();
                // Actual test code here.
            }).GetAwaiter().GetResult();

            //Pasa la prueba si no es null
            Assert.IsNotNull(listEmployees);
            //pasa la prueba si para cada tipo el calculo del salario es correcto
            foreach (var item in listEmployees)
            {
                //Assert.AreEqual(item.CalculateAnnualSalary(item.CalculateAnnualSalary(item.),item.calculatedAnnualSalary)
            }
        }
    }
}
