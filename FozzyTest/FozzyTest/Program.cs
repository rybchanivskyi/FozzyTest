using FozzyTest.Containers;
using FozzyTest.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace FozzyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //File from wich we will read employees
            const string INPUT = @"employees.xml";
            if (File.Exists(INPUT))
            {
                EmployeeList employeeList = new EmployeeList();

                try
                {
                    //Read and populate list of employees
                    employeeList.ReadListFromFile(INPUT);

                    //Sort and print list of employees to console
                    Console.WriteLine("a)\n");
                    employeeList.SortedEmployeesToConsole();

                    //Print first X employees to console where X is 5 by default
                    Console.WriteLine("\nb)\n");
                    employeeList.WriteTopEmployees(5);

                    //Print last X employees to console where X is 3 by default
                    Console.WriteLine("\nc)\n");
                    employeeList.WriteLastEmployees(3);

                    //Print sorted list to file with given path("output.txt" by default)
                    Console.WriteLine("\nd)\n");
                    employeeList.SortedEmployeesToFile();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else 
            {
                //Print error message to console if file does not exist
                Console.WriteLine($"Wrong file name - {INPUT}");
            }
            Console.WriteLine("Press any key to finish.");
            Console.ReadLine();
        }
    }
}
