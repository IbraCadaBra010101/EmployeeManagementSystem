using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
namespace EmployeeManagement
{
    public static class EmployeeDataManagement
    {
        
        // may need to go one directory higher for solution directory
        private const string path = "employees.json";

        public static void WriteDataJson(List<Employee> listOfEmployees)
        {
            var isFileNotExists = !File.Exists(path);
            if (isFileNotExists)
            {
                File.Create(path);
            }
            var isJsonFileEmpty = JsonConvert.DeserializeObject<List<Employee>>(
                File.ReadAllText(path)) == null;
            if (isJsonFileEmpty)
            {
                var employeeJson = JsonConvert.SerializeObject(listOfEmployees, Formatting.Indented);
                File.WriteAllText(path, employeeJson);
            }
            else
            {
                var existingEmployees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(path));
                listOfEmployees.AddRange(existingEmployees);
                var todoJson = JsonConvert.SerializeObject(listOfEmployees, formatting: Formatting.Indented);
                File.WriteAllText(path, todoJson);
            }
        }
        public static void OverWriteCurrentDataJson(List<Employee> listOfEmployees)
        {
            var listOfEmployeesJson = JsonConvert.SerializeObject(listOfEmployees, Formatting.Indented);
            File.WriteAllText(path, listOfEmployeesJson);
        }
        public static List<Employee> ReadData()
        {

            var currentListOfEmployees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(path));
            return currentListOfEmployees;
        }
    }
}





