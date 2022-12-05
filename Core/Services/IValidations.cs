using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IValidations
    {
        bool IsValidName(string name);
        bool IsValidEmail(string email);
        bool IsValidPassword(string password);
        bool IsValidUsername(string username);

    }
}
