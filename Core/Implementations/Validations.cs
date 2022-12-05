using System.Text.RegularExpressions;
using Core.Services;

namespace Core.Implementations
{
    public class Validations : IValidations
    {
        public bool IsValidEmail(string email)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|co.uk)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
        }

        public bool IsValidName(string name)
        {
            string regex = @"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$";
            
            return Regex.IsMatch(name, regex, RegexOptions.IgnoreCase) && name.Length > 1;
        }

        public bool IsValidPassword(string password)
        {
            string regex1 = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?.,!@$%^&*-]).{8,}$";

            return Regex.IsMatch(password, regex1);
        }

        public bool IsValidUsername(string username)
        {
            string regex = @"^[a-zA-Z\s][a-zA-Z0-9_]*$";

            return Regex.IsMatch(username, regex);
        }
    }
}