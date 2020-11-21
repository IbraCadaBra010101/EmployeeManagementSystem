using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement
{
    public static class InputOutputUtils
    {
        // menu 
        public const string PromptMenuOptions = "Select from 1.Add   2.Edit   3.Delete   4.Print   5: Print ongoing tasks  6: Print completed tasks 7: Clear screen  8: Quit ";
        public const string MenuInputError = "Error: enter a valid number from 1 to 7 to select an option!";
        // task description prompt and error prompt 
        private const string PromptTask = "Please describe the task..";
        private const string PromptValidationError = "INPUT ERROR: Text must be alphabetical characters only and can not be empty!";
        // urgency prompt and error prompt 
        // task description prompt and error prompt 
        private const string PromptUrgency = "Please enter a number from 1 to 10 to describe the the urgency of this task..";
        private const string PromptUrgencyError = "INPUT ERROR: You must enter a valid number between from 1 to 10!";
        private const string PromptNoSavedEmployees = "There is no employee data being stored at the moment";
        // edit  
        public const string PromptEditEmployee = "Enter a  number for the employee you would like to edit!";
        public const string PromptWhichDetailInEmployeeToEdit = "Enter the number for the detail you would like to edit in this task\n 1. Task description 2. Urgency rating 3. Completed 4. Assigned to";
        // which detail to edit 
        public const string PromptConfirmChosenEditableEmployee = "You chose the following employee to edit:";

 
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
            foreach (var todoContent in listOEmployees.Select((employee, index) => $"First name: {employee.FirstName} Last name: {employee.LastName} Address: {employee.AddressTuple}"))
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