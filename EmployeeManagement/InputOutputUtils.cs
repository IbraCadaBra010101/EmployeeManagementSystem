using System;
using System.Collections.Generic;

namespace EmployeeManagement
{
    public static class InputOutputUtils
    {
        // menu 
        public const string PromptMenuOptions = "Select from 1.Add   2.Edit   3.Delete   4.Print   5: Print ongoing tasks  6: Print completed tasks 7: Clear screen  8: Quit ";
        public const string MenuInputError = "Error: enter a valid number from 1 to 7 to select an option!";

        // task description prompt and error prompt 
        private const string PromptTask = "Please describe the task..";
        private const string PromptValidationError = "INPUT ERROR: Text must be alphabetical characters only and can not be empty!";
        // urgency prompt and error prompt 
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
        public const string PromptEditAnotherTodo = "Would you like to edit another contact? Answer with yes or no!";
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
        private enum MessagesEnum
        {
            DescribeTask = 0,
            ErrorTaskDescription = 1,
            EnterUrgency = 2,
            ErrorInUrgency = 3,
        }
        internal static void PrintFormatOnConsole(List<Todo> todoList)
        {
            const string appTitle = "TODO APPLICATION";
            const string frameUpperString = "╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗";
            const string frameLowerString = "╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝";
            PromptUser(appTitle);
            foreach (var todoContent in todoList.Select((todo, index) => $"Task number: {index + 1} Task: {todo.TaskDescription} Completed: {todo.IsComplete} Priority: {todo.UrgencyRating} Assigned to: {todo.AssignedTo}"))
            {
                PromptUser(frameUpperString);
                PromptUser(todoContent);
                PromptUser(frameLowerString);
            }
        }


        internal static void PrintSelectionConfirmation(Todo todo, string message)
        {
            const string frameUpperString = "╔════════════════════════════════════════════════════════════════════════════════════════╗";
            const string frameLowerString = "╚════════════════════════════════════════════════════════════════════════════════════════╝";
            var isCompleteString = $"Completed: {todo.IsComplete}";
            var ratingTodoString = $"Urgency rating: {todo.UrgencyRating}";
            var taskDescription = $"Task description: {todo.TaskDescription}";
            var assignedTo = $"Assigned to: {todo.AssignedTo}";
            PromptUser(message);
            PromptUser(frameUpperString);
            PromptUser(taskDescription);
            PromptUser(isCompleteString);
            PromptUser(ratingTodoString);
            PromptUser(assignedTo);
            PromptUser(frameLowerString);
        }

        internal static string AssignTaskTo()
        {
            PromptUser(PromptAssignTask);
            var nameOfAssignedPerson = UserInput();
            while (string.IsNullOrWhiteSpace(nameOfAssignedPerson) || int.TryParse(nameOfAssignedPerson, out _))
            {
                PromptUser(PromptAssignTaskError);
                nameOfAssignedPerson = UserInput();
            }
            return nameOfAssignedPerson;
        }

        internal static void PrintSelectionConfirmation(List<Todo> todoList, string message)
        {
            const string frameUpperString = "╔════════════════════════════════════════════════════════════════════════════════════════╗";
            const string frameLowerString = "╚════════════════════════════════════════════════════════════════════════════════════════╝";
            PromptUser(message);
            foreach (var todo in todoList)
            {
                var isCompleteString = $"Completed: {todo.IsComplete}";
                var ratingTodoString = $"Urgency rating: {todo.UrgencyRating}";
                var taskDescription = $"Task description: {todo.TaskDescription}";
                var assignedToPerson = $"Assigned to: {todo.AssignedTo}";
                PromptUser(frameUpperString);
                PromptUser(taskDescription);
                PromptUser(isCompleteString);
                PromptUser(ratingTodoString);
                PromptUser(assignedToPerson);
                PromptUser(frameLowerString);
            }
        }
        internal static void PromptUser(string message)
        {
            Console.Write($"{message}\n");
        }
        internal static string UserInput()
        {
            var userInput = Console.ReadLine();
            return userInput;
        }
        internal static void ClearConsole()
        {
            Console.Clear();
        }
        internal static int ControllerMenuInputValidateNumber(string operationInput, int minInput, int maxInput)
        {
            while (!int.TryParse(operationInput, out _) || string.IsNullOrWhiteSpace(operationInput) || int.Parse(operationInput) < minInput || int.Parse(operationInput) > maxInput)
            {
                PromptUser(PromptMenuOptions);
                PromptUser(MenuInputError);
                operationInput = Console.ReadLine();
            }
            return int.Parse(operationInput);
        }
    }
}