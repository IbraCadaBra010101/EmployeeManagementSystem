using System.IO;
using EmployeeManagement;
namespace EmployeeApplication
{
   public class AdminEmployeeLogin
    {
        private static void Main()
        {

            const string filePath = "employeeData.json";

            Login.ValidatePassword(filePath, true);

        }
    }
}
 