﻿using System;
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
                    ControllerMenu();
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
                                DetermineUserAccessLevel(t);
                                run = false;
                            }

                            messageIndex++;
                        }

                        break;
                    }
            }
        }
        internal static void DetermineUserAccessLevel(Employee employee)
        {
            if (employee.IsAdmin)
            {
                PromptUser(PromptConfirmLoggedInAsAdministrator);
                ControllerMenu();
            }
            else if(employee.IsAdmin == false)
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