using System;
using System.Collections.Generic;
using static EmployeeManagement.InputOutputUtils;
using static EmployeeManagement.InputOutputMessages;
namespace EmployeeManagement
{
    public class ValidationUtils
    {
        internal static int ValidateDetailNumber()
        {
            var userInputForDetail = UserInput();
            while (string.IsNullOrWhiteSpace(userInputForDetail) || !int.TryParse(userInputForDetail, out _) || int.Parse(userInputForDetail) < 1 || int.Parse(userInputForDetail) > 5)
            {
                PromptUser(PromptWhichDetailInEmployeeToEditError);
                userInputForDetail = UserInput();
            }
            return int.Parse(userInputForDetail);
        }
        internal static int ValidateIsValidNumber(string validateIfNumber, List<Employee> todoList)
        {
            while (!int.TryParse(validateIfNumber, out _) ||
                   string.IsNullOrWhiteSpace(validateIfNumber)
                   || !(int.Parse(validateIfNumber) > 0 && int.Parse(validateIfNumber) <= todoList.Count))
            {
                PromptUser(PromptErrorTaskNumber);
                validateIfNumber = Console.ReadLine();
            }
            return int.Parse(validateIfNumber);
        }
        internal static string ValidateText( string message, string errorMessage)
        {
            PromptUser(message);
            var employeeDetailText = UserInput();
            while (string.IsNullOrWhiteSpace(employeeDetailText) || int.TryParse(employeeDetailText, out _))
            {
                PromptUser(errorMessage);
                employeeDetailText = UserInput();
            }
            return employeeDetailText;
        }
        internal static int ControllerMenuInputValidateNumber(string operationInput)
        {
            while (!int.TryParse(operationInput, out _) || string.IsNullOrWhiteSpace(operationInput) || int.Parse(operationInput) < 1 || int.Parse(operationInput) > 9)
            {
                PromptUser(PromptMenuOptions);
                PromptUser(MenuInputError);
                operationInput = Console.ReadLine();
            }
            return int.Parse(operationInput);
        }
        internal static bool RepeatOneMoreTime(string initialMessage, string errorMessage, string agree, string decline)
        {
            PromptUser(initialMessage);
            var userInput = UserInput();
            while (userInput != agree && userInput != decline)
            {
                PromptUser(errorMessage);
                userInput = UserInput();
            }
            var answer = userInput == agree;
            return answer;
        }

        internal static Employee ChooseWhichEmployee(List<Employee> employees, string message)
        {
            PromptUser(message);
            var editEmployeeAtIndex = UserInput();
            var editThisEmployee = employees[ValidateIsValidNumber(editEmployeeAtIndex, employees) - 1];
            return editThisEmployee;
        }
        internal static bool ValidateCompleteIsBool(string message, string errorMessage)
        {
            PromptUser(message);
            var userInput = UserInput(); 
            while (string.IsNullOrWhiteSpace(userInput) || !bool.TryParse(userInput, out _))
            {
                PromptUser(errorMessage);
                userInput = Console.ReadLine();
            }
            return bool.Parse(userInput);
        }
    }
}