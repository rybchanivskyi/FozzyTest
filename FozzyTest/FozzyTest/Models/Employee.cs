using System;
using System.Collections.Generic;
using System.Text;

namespace FozzyTest.Models
{
    abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        protected double Salary { get; set; }

        protected Employee() 
        {

        }

        protected Employee(int id, string name, double salary) 
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        //Must return calculated employee`s salary
        public abstract double GetSalary();

        //Return info about employee as string (Id = "*", Name = "*", Salary = "*")
        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, Salary = {GetSalary()}";
        }
    }
}
