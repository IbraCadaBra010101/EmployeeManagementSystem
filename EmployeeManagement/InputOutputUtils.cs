using System;
using System.Collections.Generic;
using System.Linq;
using static EmployeeManagement.InputOutputMessages;
namespace EmployeeManagement
{
    public static class InputOutputUtils
    {
        
        internal static void PrintFormatOnConsole(List<Employee> listOEmployees)
        {
            const string appTitle = "Employee APPLICATION";
            const string frameUpperString = "╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗";
            const string frameLowerString = "╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝";
            PromptUser(appTitle);
            foreach (var todoContent in listOEmployees.Select((employee, index) =>
                $"First name: {employee.FirstName} Last name: {employee.LastName} Address: {employee.Address}" +
                $" ID: {employee.IdNumber}"))
            {
                PromptUser(frameUpperString);
                PromptUser(todoContent);
                PromptUser(frameLowerString);
            }
        }
        internal static void PrintSelectionConfirmation(Employee employee, string message)
        {
            const string frameUpperString = "╔════════════════════════════════════════════════════════════════════════════════════════╗";
            const string frameLowerString = "╚════════════════════════════════════════════════════════════════════════════════════════╝";
            var firstName = $"First Name: {employee.FirstName}";
            var lastName = $"Last Name: {employee.LastName}";
            var identificationNumber = $"ID number: {employee.IdNumber}";
            var address = $"Address: {employee.Address}";
            PromptUser(message);
            PromptUser(frameUpperString);
            PromptUser(lastName);
            PromptUser(address);
            PromptUser(firstName);
            PromptUser(identificationNumber);
            PromptUser(frameLowerString);
        }
        internal static void PromptUser(string message)
        {
            Console.Write($"{message}\n");
        }
        internal static string UserInput()
        {
            var userInput = Console.ReadLine();
            return userInput;
        }
        internal static void ClearConsole()
        {
            Console.Clear();
        }
    }
}