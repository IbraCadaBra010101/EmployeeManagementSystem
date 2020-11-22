namespace EmployeeManagement
{
    public class InputOutputMessages
    {
        // menu 
        public const string PromptMenuOptions = "Select from  1.Add   2.Edit   3.Delete  4.Print  5:Clear screen  6:Quit ";
        public const string MenuInputError = "Error: enter a valid number from 1 to 6 to select an option!";

        // task description prompt and error prompt 
        public const string PromptTask = "Please describe the task..";
        public const string PromptValidationError = "INPUT ERROR: Text must be alphabetical characters only and can not be empty!";
        // urgency prompt and error promt 
        // task description prompt and error prompt 
        public const string PromptUrgency = "Please enter a number from 1 to 10 to describe the the urgency of this task..";
        public const string PromptUrgencyError = "INPUT ERROR: You must enter a valid number between from 1 to 10!";

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
        public const string PromptNoSavedEmployees = "No stored employees were found!";
         
        public const string PromptEditEmployee= "Enter the number of employee you would like to edit!";
        public const string PromptEditAnotherEmployee = "Would you like to edit another employee? Answer with yes or no!";
        public const string PromptWhichDetailInEmployeeToEdit = "Enter the number for the detail you would like to edit for this employee\n 1. First name 2. Last name 3. Address 4. ID number";
        public const string PromptWhichDetailInTodoToEditError = "Error: Enter a valid number for the detail you would like to edit!\n1. Task description 2. Urgency rating 3. Completed";

        public const string PromptEditCompletionError = "Error\nEnter true for completed and false for not completed!";
        // which detail to edit 
        public const string PromptConfirmChosenEditTask = "You chose the following employee to edit:";

        public const string PromptToEditIsComplete =
            "Enter the new complete status for this task! True for completed and false for ongoing.";
        // sorting 
        public const string OngoingTask = "Viewing ongoing tasks tasks";
        public const string FinishedTask = "Viewing finished tasks tasks";
        public const string NoOngoingTasks = "No ongoing tasks at the moment";
        public const string NoCompleteTasks = "No complete tasks at the moment";
        // was deleted   
        public const string PromptWasDeleted = "Successfully deleted";
        // assign task 
        public const string PromptAssignTask = "Enter the name of the person you would like to assign this task to!";
        public const string PromptAssignTaskError =
            "Error\nEnter a name longer than one character using alphbetical characters only";
    }
}