using System;
using System.Collections.Generic;
using System.Text;

namespace FozzyTest.Models
{
    class FixedSalaryEmployee : Employee
    {
        public FixedSalaryEmployee(int id, string name, double salary): base(id, name, salary)
        {

        }
        public override double GetSalary()
        {
            return Salary;
        }
    }
}
