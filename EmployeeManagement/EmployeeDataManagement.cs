using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace EmployeeManagement
{
    public class EmployeeDataManagement
    {
        private const string TodoStorageFilePath = "todos.json";

        public static void WriteDataJson(List<Employee> todoList)
        {
            var isFileNotExists = !File.Exists(TodoStorageFilePath);
            if (isFileNotExists)
            {
                File.Create(TodoStorageFilePath);
            }
            var isJsonFileEmpty = JsonConvert.DeserializeObject<List<Employee>>(
                File.ReadAllText(TodoStorageFilePath)) == null;
            if (isJsonFileEmpty)
            {
                var todoJson = JsonConvert.SerializeObject(todoList, Formatting.Indented);
                File.WriteAllText(TodoStorageFilePath, todoJson);
            }
            else
            {
                var existingTodoList = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(TodoStorageFilePath));
                todoList.AddRange(existingTodoList);
                var todoJson = JsonConvert.SerializeObject(todoList, formatting: Formatting.Indented);
                File.WriteAllText(TodoStorageFilePath, todoJson);
            }
        }

        public static void OverWriteCurrentDataJson(List<Employee> todoList)
        {
            var todoJson = JsonConvert.SerializeObject(todoList, Formatting.Indented);
            File.WriteAllText(TodoStorageFilePath, todoJson);
        }
        public static List<Employee> ReadData()
        {
            var existingTodoList = JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText(TodoStorageFilePath));
            return existingTodoList;
        }
    }
}




