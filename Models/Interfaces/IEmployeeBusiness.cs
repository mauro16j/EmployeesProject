﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public interface IEmployeeBusiness
    {
        List<Employee> ListEmployees();
        Employee GetEmployee(int id);
    }
}
