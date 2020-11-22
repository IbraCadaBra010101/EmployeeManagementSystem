using System;

namespace EmployeeManagement
{
    public class Employee
    {
        public string IdNumber
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public bool IsAdmin
        {
            get;
            set;
        }

        public string PassWord
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;

        }
        public Employee(string idNumber, string firstName, string lastName,
            string address, bool isAdmin,
            string password, string userName)
        {
            IdNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            IsAdmin = isAdmin;
            PassWord = password;
            UserName = userName;
        }
    }
}
