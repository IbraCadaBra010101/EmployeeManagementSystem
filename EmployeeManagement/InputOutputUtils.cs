using System;
using System.Collections.Generic;
using System.Linq;
using static EmployeeManagement.InputOutputMessages;
namespace EmployeeManagement
{
    public static class InputOutputUtils
    {
       

 
        public static readonly List<string> MessageList = new List<string>()
        {
            PromptTask, PromptValidationError,PromptUrgency,PromptUrgencyError
        };
        private enum MessagesEnum
        {
            DescribeTask = 0,
            ErrorTaskDescription = 1,
            EnterUrgency = 2,
            ErrorInUrgency = 3,
        }
        internal static void PrintFormatOnConsole(List<Employee> listOEmployees)
        {
            const string appTitle = "TODO APPLICATION";
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
        internal static int ControllerMenuInputValidateNumber(string operationInput, int minInput, int maxInput)
        {
            while (!int.TryParse(operationInput, out _) || string.IsNullOrWhiteSpace(operationInput) || int.Parse(operationInput) < minInput || int.Parse(operationInput) > maxInput)
            {
                PromptUser(PromptMenuOptions);
                PromptUser(MenuInputError);
                operationInput = Console.ReadLine();
            }
            return int.Parse(operationInput);
        }

    }
}