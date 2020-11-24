using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace EmployeeManagement
{
    public static class EmployeeDataManagement
    {
        public static readonly string Path = System.IO.Path.GetFullPath(@"..\..\..\..\DataStorage\employees.json");

        public static void WriteDataJson(List<Employee> listOfEmployees)
        {
            var isFileNotExists = !File.Exists(Path);
            if (isFileNotExists)
            { 
                File.Create(Path);
            }
            var isJsonFileEmpty = JsonConvert.DeserializeObject<List<Employee>>(
                File.ReadAllText(Path)) == null;
            if (isJsonFileEmpty)
            {
                var employeeJson = JsonConvert.SerializeObject(listOfEmployees, Formatting.Indented);
                File.WriteAllText(Path, employeeJson);
            }
            else
            {
                var existingEmployees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(Path));
                listOfEmployees.AddRange(existingEmployees);
                var todoJson = JsonConvert.SerializeObject(listOfEmployees, formatting: Formatting.Indented);
                File.WriteAllText(Path, todoJson);
            }
        }
        public static void OverWriteCurrentDataJson(List<Employee> listOfEmployees)
        {
            var listOfEmployeesJson = JsonConvert.SerializeObject(listOfEmployees, Formatting.Indented);
            File.WriteAllText(Path, listOfEmployeesJson);
        }
        public static List<Employee> ReadData()
        {

            var currentListOfEmployees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(Path));
            return currentListOfEmployees;
        }
    }
}





