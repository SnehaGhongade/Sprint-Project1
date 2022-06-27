using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Api.ViewModel
{
    public class Tokens
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
        public bool IsAdmin { get; internal set; }
    }
}
