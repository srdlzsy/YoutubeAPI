using Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(UserRegistrationDto userRegistrationDto);
        Task<string> Login(UserLoginDto userLoginDto);
    }
}
