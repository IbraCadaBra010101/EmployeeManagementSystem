using System;
using static EmployeeManagement.InputOutputUtils;
using static EmployeeManagement.ValidationUtils;
using static EmployeeManagement.Crud;
using static EmployeeManagement.InputOutputMessages;
using static EmployeeManagement.Login;
namespace EmployeeManagement
{
    public static class CrudOperationsController
    {
        public static void ControllerMenu(bool isAdmin)
        {
            PromptUser(PromptMenuOptions);
            var chooseOperationInput = UserInput();
            var validNumberOperationInput = ControllerMenuInputValidateNumber(chooseOperationInput);
            while (true)
            {
                switch (validNumberOperationInput)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Edit();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Print();
                        break;
                    case 5:
                        ClearConsole();
                        break;
                    case 6:
                        ClearConsole();
                        ValidatePassword(isAdmin);
                        break;
                    default:
                        return;
                }
                PromptUser(PromptMenuOptions);
                chooseOperationInput = UserInput();
                validNumberOperationInput = ControllerMenuInputValidateNumber(chooseOperationInput);
            }
        }

    }
}
