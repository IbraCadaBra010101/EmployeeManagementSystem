using System;

namespace EmployeeManagement
{
    public class Employee
    {
        internal string IdNumber
        {
            get;
            set;
        }
        internal string FirstName
        {
            get;
            set;
        }
        internal string LastName
        {
            get;
            set;
        }
        internal bool IsAdmin
        {
            get;
            set;
        }

        internal string PassWord
        {
            get;
            set;
        }
        internal string UserName
        {
            get;
            set;
        }
        internal string Address
        {
            get;
            set;

        }
        public Employee(string idNumber, string firstName, string lastName,
            string address, bool isAdmin,
            string password)
        {
            IdNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            IsAdmin = isAdmin;
            PassWord = password;
            UserName = firstName + lastName;
        }
    }
}
