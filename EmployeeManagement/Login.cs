

using System;
using System.Collections.Generic;
using System.Text;
using static EmployeeManagement.CrudOperationsController;
using static EmployeeManagement.InputOutputUtils;
using static EmployeeManagement.ValidationUtils;
using static EmployeeManagement.InputOutputMessages;
namespace EmployeeManagement
{
    class Program
    {
        public static void Main()
        {
        }
    }
    internal static class Login
    {
        private const string EmployeeDetailsMessage = "Your Employee Details";
        private const string WrongLogin = "Login failed, wrong password or/and username!";
        private const string InputError = "Answer with either yes/no only!";
        private const string EnterPassword = "Enter your password!";
        private const string EnterUsername = "Enter your username!";

        internal static string GenerateNumericPassword()
        {
            var allNumbers = new List<int>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            var passwordLength = 4;
            var random = new Random();
            var stringBuilder = new StringBuilder();
            while (passwordLength-- > 0)
            {
                var number = random.Next(allNumbers.Count);
                stringBuilder.Append(number);
            }
            return stringBuilder.ToString();
        }
        public static int ValidatePassword(List<Employee> listOfEmployees)
        {
            var runForOneMoreTry = true;

            var passWordInput = Console.ReadLine();
            PromptUser(EnterUsername);
            var userNameInput = Console.ReadLine();
            PromptUser(EnterPassword);

            while (runForOneMoreTry)
            {
                foreach (var employee in listOfEmployees)
                {
                    if ($"{employee.FirstName}{employee.LastName}" == userNameInput
                        && employee.PassWord == passWordInput)
                    {
                        DetermineUserAccessLevel(employee);
                        runForOneMoreTry = false;
                    }
                    else
                    {
                        runForOneMoreTry = RepeatOneMoreTime(WrongLogin, InputError, Yes, No);
                        passWordInput = Console.ReadLine();
                        PromptUser(EnterUsername);
                        userNameInput = Console.ReadLine();
                        PromptUser(EnterPassword);
                    }
                }
            }
            return 0;
        }

        internal static void DetermineUserAccessLevel(Employee employee)
        {
            if (employee.IsAdmin)
            {
                ControllerMenu();
            }
            else
            {
                PrintSelectionConfirmation(employee, EmployeeDetailsMessage);
            }
        }

        internal static string GenerateNewIdNumber()
        {
            var guidObj = new Guid();
            var idNumber = guidObj.ToString();
            return idNumber;
        }
    }
}