using System;
using System.Collections.Generic;
using System.Text;

namespace FozzyTest.Models
{
    class HourlySalaryEmployee : Employee
    {
        public HourlySalaryEmployee(int id, string name, double salary): base(id, name, salary)
        {

        }
        public override double GetSalary()
        {
            return 20.8 * 8 * Salary;
        }
    }
}
