using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EmployeeManagement
{
    public static class EmployeeDataManagement
    {
        public static void WriteDataJson(List<Employee> listOfEmployees, string path)
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
                var todoJson = JsonConvert.SerializeObject(listOfEmployees, Formatting.Indented);
                File.WriteAllText(path, todoJson);
            }
            else
            {
                var existingEmployees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(path));
                listOfEmployees.AddRange(existingEmployees);
                var todoJson = JsonConvert.SerializeObject(listOfEmployees, formatting: Formatting.Indented);
                File.WriteAllText(path, todoJson);
            }
        }
        public static void OverWriteCurrentDataJson(List<Employee> listOfEmployees, string path)
        { 
            var listOfEmployeesJson = JsonConvert.SerializeObject(listOfEmployees, Formatting.Indented);
            File.WriteAllText(path, listOfEmployeesJson);
        }
        public static List<Employee> ReadData(string path)
        {
            var currentListOfEmployees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(path));
            return currentListOfEmployees;
        }
    }
}





