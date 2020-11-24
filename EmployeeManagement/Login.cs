using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static EmployeeManagement.CrudOperationsController;
using static EmployeeManagement.InputOutputUtils;
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
        public static void ValidatePassword(bool isAdmin)
        {
            var listOfEmployees = ReadData();
            var run = true;
            var messageIndex = 0;
            switch (listOfEmployees.Count)
            {
                case 0 when isAdmin:
                    ControllerMenu(isAdmin);
                    break;
                case 0 when !isAdmin:
                    PromptUser("List is empty, log in as admin or ask admin to create an account!");
                    break;
                default:
                    {
                        while (run)
                        {

                            if (messageIndex > 0)
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
                            foreach (var t in listOfEmployees.Where(t => $"{t.FirstName + t.LastName}" == userNameInput && t.PassWord == passWordInput))
                            {
                                DetermineUserAccessLevel(t, isAdmin);
                                run = false;
                            }
                            messageIndex++;
                        }

                        break;
                    }
            }
        }
        internal static void DetermineUserAccessLevel(Employee employee, bool isAdmin)
        {
            if (employee.IsAdmin && isAdmin || employee.IsAdmin == false && isAdmin)
            {
                PromptUser(PromptConfirmLoggedInAsAdministrator);
                ControllerMenu(isAdmin);
            }
            else if(employee.IsAdmin == false && isAdmin == false)
            {
                PromptUser(PromptConfirmLoggedInAsEmployee);
                PrintSelectionConfirmation(employee, EmployeeDetailsMessage);
            }
            else
            {
                PromptUser("You do not have access to login to an admin account from an employee application");
            }
        }
      internal static string GenerateNewIdNumber()
        {
            var guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}