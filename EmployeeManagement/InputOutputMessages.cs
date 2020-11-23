namespace EmployeeManagement
{
    public class InputOutputMessages
    {
        // id number was generated 
        public const string PromptNewIdNumberCreated = "Generated a new ID number: ";

        // edit/add  messages 
        public const string PromptNewFirstName = "Enter the new first name!";
        public const string PromptNewFirstNameError = "Error, input was not valid!\nEnter the new first name!";

        public const string PromptNewLastName = "Enter the new last name!";
        public const string PromptNewLastNameError = "Error, input was not valid!\nEnter the new last name!";


        public const string PromptNewAddress = "Enter the new address!";
        public const string PromptNewAddressError = "Error, input was not valid!\nEnter the new address!";

        public const string PromptMakeAdmin = "Enter true to make user admin or false to limit access!";
        public const string PromptMakeAdminError = "Error, input was not valid!\nMust be true or false!";
        // menu 
        public const string PromptMenuOptions = "Select from  1.Add   2.Edit   3.Delete  4.Print  5:Clear screen  6:Quit ";
        public const string MenuInputError = "Error: enter a valid number from 1 to 6 to select an option!";

        public const string Yes = "yes";
        public const string No = "no";
        // repeat action on more time in adding
        public const string PromptAddAnotherEmployee = "Would you like to add another employee? Answer with yes or no!";
        public const string PromptRepeatErrorMessage = "ERROR You can only answer with yes or no!";
        // delete task 
        public const string PromptDeleteEmployee = "Enter the number for the employee you would like to delete!";
        public const string PromptErrorTaskNumber = "ERROR Enter a valid number!";
        // delete one more task   
        public const string PromptDeleteAnotherTodo = "Would you like to delete another contact? Answer with yes or no!";
        // edit 
        public const string PromptNoSavedEmployees = "Empty database, Add some employees!!";

        public const string PromptEditEmployee = "Enter the number of employee you would like to edit!";
        public const string PromptEditAnotherEmployee = "Would you like to edit another employee? Answer with yes or no!";
        public const string PromptWhichDetailInEmployeeToEdit = "Enter the number for the detail you would like to edit for this employee\n 1. First name 2. Last name 3. Address 4. ID number";
        public const string PromptWhichDetailInTodoToEditError = "Error: Enter a valid number for the detail you would like to edit!\n1. Task description 2. Urgency rating 3. Completed";

        public const string PromptDetermineIfAdminInputError = "Error\nEnter true to make this user admin or false to make employee!";
        // which detail to edit 
        public const string PromptConfirmChosenEditTask = "You chose the following employee to edit:";

        public const string PromptToEditIsComplete =
            "Enter the new complete status for this task! True for completed and false for ongoing.";
        // was deleted   
        public const string PromptWasDeleted = "Successfully deleted";
        public const string PromptAllDeleted = "All contacts were deleted";
        public const string EmployeeDetailsMessage = "Your Employee Details";
        public const string WrongLogin = "Login failed, try again!";
        public const string InputError = "Please answer with yes or no only!";
        public const string EnterPassword = "Enter your password!";
        public const string EnterUsername = "Enter your username!";
        public const string PromptConfirmLoggedInAsEmployee = "Logged in as employee";

        public const string PromptConfirmLoggedInAsAdministrator = "Logged in as Administrator!";

    }
}