

using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static EmployeeManagement.CrudOperationsController;
using static EmployeeManagement.InputOutputUtils;
using static EmployeeManagement.ValidationUtils;
using static EmployeeManagement.InputOutputMessages;
using static EmployeeManagement.EmployeeDataManagement;
namespace EmployeeManagement
{
    public static class Login
    {
     

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
        public static void ValidatePassword(string path, bool nonAdmin)
        {
            var listOfEmployees = ReadData(path);
            var run = true;
            var messageIndex = 0;
            if (listOfEmployees.Count < 1 && nonAdmin ==  false)
            {
                ControllerMenu(path);
            }
            if (listOfEmployees.Count < 1 && nonAdmin)
            {
               PromptUser("You are an employee with no admin priviliges, ask the admin to  create an account for you");
            }
            else
            {
                while (run)
                {

                    if (messageIndex >  0)
                    {
                        PromptUser(WrongLogin);
                    }
                    PromptUser(EnterUsername);
                    var userNameInput = Console.ReadLine();

                    PromptUser(EnterPassword);
                    var passWordInput = Console.ReadLine();
                    if (userNameInput == "quit" || passWordInput == "quit")
                    {
                         run = false;
                    }
                    for (int index = 0; index < listOfEmployees.Count; index++)
                    {
                        if ($"{listOfEmployees[index].FirstName + listOfEmployees[index].LastName}" == userNameInput
                            && listOfEmployees[index].PassWord == passWordInput)
                        {
                            DetermineUserAccessLevel(listOfEmployees[index], path, nonAdmin);
                            run = false;
                        }
                    }

                    messageIndex++;
                }
       
            }
        }
        internal static void DetermineUserAccessLevel(Employee employee, string path, bool nonAdmin)
        {
            if (employee.IsAdmin && nonAdmin == false)
            {
                PromptUser(PromptConfirmLoggedInAsAdministrator);
                ControllerMenu(path);
            }
            else
            {
                PromptUser(PromptConfirmLoggedInAsEmployee);
                PrintSelectionConfirmation(employee, EmployeeDetailsMessage);
            }
        }
        internal static string GenerateNewIdNumber(string message)
        {
            var guidObj = new Guid();
            var idNumber = guidObj.ToString();
            return idNumber;
        }
    }
}