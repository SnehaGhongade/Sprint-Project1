using E_Commerce_Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Api.Interfaces
{
    public interface IJWTMangerRepository
    {
        Tokens Authenicate(LoginViewModel users, bool IsRegister);
    }
}
