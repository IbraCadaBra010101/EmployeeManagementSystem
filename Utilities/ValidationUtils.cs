using System;
using System.Collections.Generic;

namespace EmployeeManagement
{ 
    public class ValidationUtils
    {
        private enum MessagesEnum
        {
            DescribeTask = 0,
            ErrorTaskDescription = 1,
            EnterUrgency = 2,
            ErrorInUrgency = 3,
        }
        public static string ValidateText()
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

    }
}