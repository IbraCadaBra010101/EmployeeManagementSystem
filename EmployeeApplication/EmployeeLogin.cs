using System.IO;
using EmployeeManagement;
namespace EmployeeApplication
{
   public class EmployeeLogin
    {
        private static void Main()
        {

            const string filePath = "employeeData.json";

            Login.ValidatePassword(filePath);

        }
    }
}
 