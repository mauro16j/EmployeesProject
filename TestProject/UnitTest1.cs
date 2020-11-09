using System;
using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BusinessListEmployees()
        {
            var objBusiness = new EmployeeBusiness();
            var listEmployees = objBusiness.ListEmployees();
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
