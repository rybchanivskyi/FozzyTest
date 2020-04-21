using FozzyTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace FozzyTest.Containers
{
    class EmployeeList : List<Employee>
    {
        private List<Employee> SortedEmployees => SortEmployees();


        //Sort employees in descending average monthly earnings, then by name
        private List<Employee> SortEmployees()
        {
            return this.OrderByDescending(employee => employee.GetSalary()).ThenBy(employee => employee.Name).ToList();
        }

        //Open and read Xml Document
        public void ReadListFromFile(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);

            XmlNodeList employeeType = xmlDocument.GetElementsByTagName("Employee");
            XmlNodeList employeeId = xmlDocument.GetElementsByTagName("id");
            XmlNodeList employeeNames = xmlDocument.GetElementsByTagName("name");
            XmlNodeList employeeSalary = xmlDocument.GetElementsByTagName("salary");

            PopulateList(employeeType, employeeId, employeeNames, employeeSalary);
        }

        //Populate employee`s list
        private void PopulateList(XmlNodeList employeeType, XmlNodeList employeeId, XmlNodeList employeeNames, XmlNodeList employeeSalary)
        {
            int counter = 0;

            foreach (XmlNode type in employeeType)
            {
                XmlAttributeCollection xmlAttributeCollection = type.Attributes;
                Employee currentEmployee;
                if (xmlAttributeCollection != null && xmlAttributeCollection["type"].Value == "1")
                {
                    currentEmployee = new FixedSalaryEmployee(int.Parse(employeeId[counter].InnerText), employeeNames[counter].InnerText,
                        double.Parse(employeeSalary[counter].InnerText));
                }
                else
                {
                    currentEmployee = new HourlySalaryEmployee(int.Parse(employeeId[counter].InnerText), employeeNames[counter].InnerText,
                        double.Parse(employeeSalary[counter].InnerText));
                }
                Add(currentEmployee);
                counter++;
            }
        }

        //Write given list of employees to console
        public void WriteEmployeesToConsole(IEnumerable<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }

        //Write given list of employees to file (default file is "output.txt")
        public void WriteEmployeesToFile(IEnumerable<Employee> employees, string fileName = "output.txt")
        {
            try 
            {
                using (StreamWriter file = new StreamWriter(fileName))
                {
                    foreach (Employee employee in employees)
                    {
                        file.WriteLine(employee);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        //Write sorted list of employees to console
        public void SortedEmployeesToConsole()
        {
            Console.WriteLine("Sorted list of employees: ");
            WriteEmployeesToConsole(SortedEmployees);
        }

        //Write sorted list of employees to file(default file is output.txt)
        public void SortedEmployeesToFile(string fileName = "output.txt")
        {
            WriteEmployeesToFile(SortedEmployees, fileName);
            Console.WriteLine($"Sorted list was written to file - {Environment.CurrentDirectory}\\{fileName}\n");
        }

        //Print to console top "numOfElement" elements of sorted list
        public void WriteTopEmployees(int numOfEmployees)
        {
            //Check if we have enough items in list
            numOfEmployees = Math.Min(numOfEmployees, SortedEmployees.Count());

            Console.WriteLine($"The first {numOfEmployees} employees:");
            IEnumerable<Employee> topEmployees = SortedEmployees.Take(numOfEmployees);
            WriteEmployeesToConsole(topEmployees);
        }

        //Print to console last "numOfElement" elements of sorted list
        public void WriteLastEmployees(int numOfEmployees)
        {
            //Check if we have enough items in list
            numOfEmployees = Math.Min(numOfEmployees, SortedEmployees.Count());

            Console.WriteLine($"Last {numOfEmployees} employees: ");
            WriteEmployeesToConsole(SortedEmployees.TakeLast(numOfEmployees));
        }
    }
}
