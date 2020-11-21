using System;
using System.Collections.Generic;
using static EmployeeManagement.InputOutputUtils;

namespace EmployeeManagement
{
    public class ValidationUtils
    {

        // menu 
        public const string PromptMenuOptions = "Select from 1.Add   2.Edit   3.Delete   4.Print   5: Print ongoing tasks  6: Print completed tasks 7: Clear screen  8: Quit ";
        public const string MenuInputError = "Error: enter a valid number from 1 to 7 to select an option!";

        // task description prompt and error prompt 
        private const string PromptTask = "Please describe the task..";
        private const string PromptValidationError = "INPUT ERROR: Text must be alphabetical characters only and can not be empty!";
        // urgency prompt and error promt 
        // task description prompt and error prompt 
        private const string PromptUrgency = "Please enter a number from 1 to 10 to describe the the urgency of this task..";
        private const string PromptUrgencyError = "INPUT ERROR: You must enter a valid number between from 1 to 10!";

        public const string Yes = "yes";
        public const string No = "no";
        // repeat action on more time in adding
        public const string PromptAddAnotherTodo = "Would you like to add another contact? Answer with yes or no!";
        public const string PromptRepeatErrorMessage = "ERROR You can only answer with yes or no!";
        // delete task 
        public const string PromptDeleteTask = "Enter the task number for the task you would like to delete!";
        public const string PromptErrorTaskNumber = "ERROR Enter a valid number!";
        // delete one more task   
        public const string PromptDeleteAnotherTodo = "Would you like to delete another contact? Answer with yes or no!";
        // edit
        public const string PromptEditTask = "Enter the task number for the task you would like to edit!";
        public const string PromptEditAnotherEmployee = "Would you like to edit another contact? Answer with yes or no!";
        public const string PromptWhichDetailInTodoToEdit = "Enter the number for the detail you would like to edit in this task\n 1. Task description 2. Urgency rating 3. Completed 4. Assigned to";
        public const string PromptWhichDetailInTodoToEditError = "Error: Enter a valid number for the detail you would like to edit!\n1. Task description 2. Urgency rating 3. Completed";

        public const string PromptEditCompletionError = "Error\nEnter true for completed and false for not completed!";
        // which detail to edit 
        public const string PromptConfirmChosenEditTask = "You chose the following task to edit:";

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
        private static readonly List<string> MessageList = new List<string>()
        {
            PromptTask, PromptValidationError,PromptUrgency,PromptUrgencyError
        };

        internal enum MessagesEnum
        {
            DescribeTask = 0,
            ErrorTaskDescription = 1,
            EnterUrgency = 2,
            ErrorInUrgency = 3,
        }
        internal static int ValidateDetailNumber()
        {
            var userInputForDetail = UserInput();
            while (string.IsNullOrWhiteSpace(userInputForDetail) || !int.TryParse(userInputForDetail, out _) || int.Parse(userInputForDetail) < 1 || int.Parse(userInputForDetail) > 4)
            {
                PromptUser(PromptWhichDetailInTodoToEditError);
                userInputForDetail = UserInput();
            }
            return int.Parse(userInputForDetail);
        }
        internal static int ValidateIsValidNumber(string validateIfNumber, List<Employee> todoList)
        {
            while (!int.TryParse(validateIfNumber, out _) ||
                   string.IsNullOrWhiteSpace(validateIfNumber)
                   || !(int.Parse(validateIfNumber) > 0 && int.Parse(validateIfNumber) <= todoList.Count))
            {
                PromptUser(PromptErrorTaskNumber);
                validateIfNumber = Console.ReadLine();
            }
            return int.Parse(validateIfNumber);
        }
        internal static string ValidateText()
        {
            const int taskMessage = (int)MessagesEnum.DescribeTask;
            const int errorTaskMessage = (int)MessagesEnum.ErrorTaskDescription;
            PromptUser(MessageList[taskMessage]);
            var taskDescriptionInput = UserInput();
            while (string.IsNullOrWhiteSpace(taskDescriptionInput) || int.TryParse(taskDescriptionInput, out _))
            {
                PromptUser(MessageList[errorTaskMessage]);
                taskDescriptionInput = UserInput();
            }
            return taskDescriptionInput;
        }
        internal static int ValidateEmployeeExists(string validateIfNumber, List<Employee> todoList)
        {
            while (!int.TryParse(validateIfNumber, out _) ||
                   string.IsNullOrWhiteSpace(validateIfNumber)
                   || !(int.Parse(validateIfNumber) > 0 && int.Parse(validateIfNumber) <= todoList.Count))
            {
                PromptUser(PromptErrorTaskNumber);
                validateIfNumber = Console.ReadLine();
            }
            return int.Parse(validateIfNumber);
        }
        internal static int ControllerMenuInputValidateNumber(string operationInput)
        {
            while (!int.TryParse(operationInput, out _) || string.IsNullOrWhiteSpace(operationInput) || int.Parse(operationInput) < 1 || int.Parse(operationInput) > 9)
            {
                PromptUser(PromptMenuOptions);
                PromptUser(MenuInputError);
                operationInput = Console.ReadLine();
            }
            return int.Parse(operationInput);
        }
        internal static bool RepeatOneMoreTime(string initialMessage, string errorMessage, string agree, string decline)
        {
            PromptUser(initialMessage);
            var userInput = UserInput();
            while (userInput != agree && userInput != decline)
            {
                PromptUser(errorMessage);
                userInput = UserInput();
            }
            var answer = userInput == agree;
            return answer;
        }

    }
}