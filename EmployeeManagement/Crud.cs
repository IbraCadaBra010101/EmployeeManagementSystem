using System;
using System.Collections.Generic;
using static EmployeeManagement.EmployeeDataManagement;
using static EmployeeManagement.InputOutputUtils;
using static EmployeeManagement.ValidationUtils;
using static EmployeeManagement.Login;
using static EmployeeManagement.InputOutputMessages;

namespace EmployeeManagement
{
   public static class Crud

    {
        internal static void Print()
        {
            var lisOfEmployees = ReadData();
            InputOutputUtils.PrintFormatOnConsole(lisOfEmployees);
        }
        internal static void Edit()
        {
            var listOfEmployees = ReadData();
            var editMoreEmployees = true;
            while (editMoreEmployees && listOfEmployees.Count > 0)
            {
                Print();
                PromptUser(PromptEditEmployee);
                var editEmployeeAtIndex = UserInput();
                var editThisEmployee = listOfEmployees[ValidateIsValidNumber(editEmployeeAtIndex, listOfEmployees) - 1];
                PrintSelectionConfirmation(editThisEmployee, PromptConfirmChosenEditTask);
                PromptUser(PromptWhichDetailInEmployeeToEdit);
                var validDetailNumber = ValidateDetailNumber();
                switch (validDetailNumber) 
                {
                    case 1:
                        editThisEmployee.FirstName = ValidateText();
                        break;
                    case 2:
                        editThisEmployee.LastName = ValidateText();
                        break;
                    case 3:
                        PromptUser(PromptToEditIsComplete);
                        editThisEmployee.Address = ValidateText();
                        break;
                    case 4:
                        editThisEmployee.IdNumber = GenerateNewIdNumber();
                        break;
                }
                OverWriteCurrentDataJson(listOfEmployees);
                Print();
                var stopOrRepeat = RepeatOneMoreTime(PromptEditAnotherEmployee,
                    PromptRepeatErrorMessage, Yes, No);
                editMoreEmployees = stopOrRepeat;
            }
        }
        internal static void Delete()
        {

            var listOfEmployees = ReadData();
            if (listOfEmployees.Count <= 0)
            {
                PromptUser(PromptNoSavedEmployees);
            }
            else
            {
                Print();
                var deleteMoreEmployees = true;
                while (deleteMoreEmployees && listOfEmployees.Count > 0)
                {
                    PromptUser(PromptDeleteEmployee);
                    var deleteEmployeeAtIndex = UserInput();
                    var deleteThisEmployee = listOfEmployees[ValidateIsValidNumber(deleteEmployeeAtIndex, listOfEmployees) - 1];
                    listOfEmployees.Remove(deleteThisEmployee);
                    ClearConsole();
                    OverWriteCurrentDataJson(listOfEmployees);
                    Print();
                    PrintSelectionConfirmation(deleteThisEmployee, PromptWasDeleted);
                    if (listOfEmployees.Count <= 0)
                    {
                        PromptUser("All contacts were deleted");
                        break;
                    };
                    var stopOrRepeat = RepeatOneMoreTime(PromptDeleteAnotherTodo,
                        PromptRepeatErrorMessage, Yes, No);
                    deleteMoreEmployees = stopOrRepeat;
                }
            }
        }
        internal static void Add()
        {
            var addMoreEmployees = true;
            var listOfEmployees = new List<Employee>();
            while (addMoreEmployees)
            {
                var idNumber = GenerateNewIdNumber();
                var firstName = ValidateText();
                var lastName = ValidateText();
                var address = ValidateText();
                var passWord = GenerateNumericPassword();
                var task = new Employee(idNumber, firstName, lastName, address,false, passWord);
                listOfEmployees.Add(task);
                var stopOrRepeat = RepeatOneMoreTime(PromptAddAnotherTodo,
                    PromptRepeatErrorMessage, Yes, No);
                addMoreEmployees = stopOrRepeat;
            }
            ClearConsole();
            WriteDataJson(listOfEmployees);
            Print();
        }
    }

}
