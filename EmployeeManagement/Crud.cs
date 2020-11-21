using System;
using System.Collections.Generic;
using static EmployeeManagement.EmployeeDataManagement;
using static EmployeeManagement.InputOutputUtils;
using static EmployeeManagement.ValidationUtils;
using static EmployeeManagement.Login;

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
                PrintSelectionConfirmation(editThisEmployee, PromptConfirmChosenEditableEmployee);
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

            var todoList = ReadData();
            if (todoList.Count <= 0)
            {
                PromptUser("No saved contacts");
            }
            else
            {
                Print();
                var userWantsToDeleteMoreTasks = true;
                while (userWantsToDeleteMoreTasks && todoList.Count > 0)
                {
                    PromptUser(PromptDeleteTask);
                    var deleteThisTaskUserInput = UserInput();
                    var deletedTask = todoList[ValidateIsValidNumber(deleteThisTaskUserInput, todoList) - 1];
                    todoList.Remove(deletedTask);
                    ClearConsole();
                    OverWriteCurrentDataJson(todoList);
                    Print();
                    PrintSelectionConfirmation(deletedTask, PromptWasDeleted);
                    if (todoList.Count <= 0)
                    {
                        PromptUser("All contacts were deleted");
                        break;
                    };
                    var stopOrRepeat = RepeatOneMoreTime(PromptDeleteAnotherTodo,
                        PromptRepeatErrorMessage, Yes, No);
                    userWantsToDeleteMoreTasks = stopOrRepeat;
                }
            }
        }
        internal static void Add()
        {
            var userWantsToAddMoreTasks = true;
            var todoList = new List<Employee>();
            while (userWantsToAddMoreTasks)
            {
                var taskDescription = ValidateText();
                var urgencyRating = int.Parse(ValidateUrgency());
                var assignTo = AssignTaskTo();
                var task = new Employee(taskDescription, urgencyRating, false, assignTo);
                todoList.Add(task);
                var stopOrRepeat = RepeatOneMoreTime(PromptAddAnotherTodo,
                    PromptRepeatErrorMessage, Yes, No);
                userWantsToAddMoreTasks = stopOrRepeat;
            }
            ClearConsole();
            WriteDataJson(todoList);
            Print();
        }
    }

}
