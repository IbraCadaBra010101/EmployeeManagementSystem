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
        public static void Print(string path)
        {
            var lisOfEmployees = ReadData(path);
            InputOutputUtils.PrintFormatOnConsole(lisOfEmployees);
        }
        public static void Edit(string path)
        {
            var listOfEmployees = ReadData(path);
            var editMoreEmployees = true;

            while (editMoreEmployees && listOfEmployees.Count > 0)
            {
                Print(path);
                var editThisEmployee = ChooseWhichEmployee(listOfEmployees, PromptEditEmployee);
                PrintSelectionConfirmation(editThisEmployee, PromptConfirmChosenEditTask);
                PromptUser(PromptWhichDetailInEmployeeToEdit);
                var validDetailNumber = ValidateDetailNumber();
                switch (validDetailNumber)
                {
                    case 1:
                        editThisEmployee.FirstName = ValidateText(PromptNewFirstName, PromptNewFirstNameError);
                        break;
                    case 2:
                        editThisEmployee.LastName = ValidateText(PromptNewLastName, PromptNewLastNameError);
                        break;
                    case 3:
                        editThisEmployee.Address = ValidateText(PromptNewAddress, PromptNewAddressError);
                        break;
                    case 4:
                        editThisEmployee.IsAdmin = ValidateCompleteIsBool(PromptMakeAdmin, PromptMakeAdminError);
                        break;
                    case 5:
                        editThisEmployee.IdNumber = GenerateNewIdNumber(PromptNewIdNumberCreated);
                        break;
                }
                OverWriteCurrentDataJson(listOfEmployees, path);
                Print(path);
                var stopOrRepeat = RepeatOneMoreTime(PromptEditAnotherEmployee,
                    PromptRepeatErrorMessage, Yes, No);
                editMoreEmployees = stopOrRepeat;
            }
        }
        public static void Delete(string path)
        {
            var listOfEmployees = ReadData(path);
            if (listOfEmployees.Count <= 0)
            {
                PromptUser(PromptNoSavedEmployees);
            }
            else
            {
                Print(path);
                var deleteMoreEmployees = true;
                while (deleteMoreEmployees && listOfEmployees.Count > 0)
                {
                    var deleteThisEmployee = ChooseWhichEmployee(listOfEmployees, PromptDeleteEmployee);
                    listOfEmployees.Remove(deleteThisEmployee);
                    ClearConsole();
                    OverWriteCurrentDataJson(listOfEmployees, path);
                    Print(path);
                    PrintSelectionConfirmation(deleteThisEmployee, PromptWasDeleted);
                    if (listOfEmployees.Count <= 0)
                    {
                        PromptUser(PromptAllDeleted);
                        break;
                    }
                    var stopOrRepeat = RepeatOneMoreTime(PromptDeleteAnotherTodo,
                        PromptRepeatErrorMessage, Yes, No);
                    deleteMoreEmployees = stopOrRepeat;
                }
            }
        }
        public static void Add(string path)
        {
            var addMoreEmployees = true;
            var listOfEmployees = new List<Employee>();
            while (addMoreEmployees)
            {
                var idNumber = GenerateNewIdNumber(PromptNewIdNumberCreated);
                var firstName = ValidateText(PromptNewFirstName, PromptNewFirstNameError);
                var lastName = ValidateText(PromptNewLastName, PromptNewLastNameError);
                var address = ValidateText(PromptNewAddress, PromptNewAddressError);
                var passWord = GenerateNumericPassword();
                var isEmployeeAdmin = ValidateCompleteIsBool(PromptMakeAdmin, PromptMakeAdminError);
                var employee = new Employee(idNumber, firstName, lastName, address, isEmployeeAdmin, passWord, firstName + lastName);
                listOfEmployees.Add(employee);
                var stopOrRepeat = RepeatOneMoreTime(PromptAddAnotherEmployee,
                    PromptRepeatErrorMessage, Yes, No);
                addMoreEmployees = stopOrRepeat;
            }
            ClearConsole();
            WriteDataJson(listOfEmployees, path);
            Print(path);
        }
    }

}
