using EmployeeManagement;

namespace LimitedEmployee
{
    class Employee
    {
        static void Main(string[] args)
        {
            const string filePath = "NonAdminEmployeeData.json";
            const bool nonAdmin = true;
            Login.ValidatePassword(filePath, nonAdmin);
        }
    }
}
