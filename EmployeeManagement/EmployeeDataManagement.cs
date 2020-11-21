using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EmployeeManagement
{
    public static class EmployeeDataManagement
    {
        private const string EmployeeFilePath = "emloyeeData.json";

        public static void WriteDataJson(List<Employee> listOfEmployees)
        {
            var isFileNotExists = !File.Exists(EmployeeFilePath);
            if (isFileNotExists)
            {
                File.Create(EmployeeFilePath);
            }
            var isJsonFileEmpty = JsonConvert.DeserializeObject<List<Employee>>(
                File.ReadAllText(EmployeeFilePath)) == null;
            if (isJsonFileEmpty)
            {
                var todoJson = JsonConvert.SerializeObject(listOfEmployees, Formatting.Indented);
                File.WriteAllText(EmployeeFilePath, todoJson);
            }
            else
            {
                var existingTodoList = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(EmployeeFilePath));
                listOfEmployees.AddRange(existingTodoList);
                var todoJson = JsonConvert.SerializeObject(listOfEmployees, formatting: Formatting.Indented);
                File.WriteAllText(EmployeeFilePath, todoJson);
            }
        }

        public static void OverWriteCurrentDataJson(List<Employee> listOfEmployees)
        {
            var listOfEmployeesJson = JsonConvert.SerializeObject(listOfEmployees, Formatting.Indented);
            File.WriteAllText(EmployeeFilePath, listOfEmployeesJson);
        }
        public static List<Employee> ReadData()
        {
            var currentListOfEmployees = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(EmployeeFilePath));
            return currentListOfEmployees;
        }
    }
}




