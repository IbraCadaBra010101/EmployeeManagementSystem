using System;

namespace EmployeeManagement
{
    public class Employee
    {
        private long IdNumber
        {
            get;
            set;
        }
        private string FirstName
        {
            get;
            set; 
        }
        private string LastName
        {
            get;
            set;
        }
        private bool IsAdmin = false;
        private Tuple<string, int, string, int> AddressTuple
        {
            get;
            set;
        }

        public Employee(long idNumber, string firstName, string lastName,
            Tuple<string, int, string, int> addressTuple, bool isAdmin )
        {
            IdNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            AddressTuple = addressTuple;
            IsAdmin = isAdmin;
        }
    }
}
