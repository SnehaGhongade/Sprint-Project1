using E_Commerce_Api.Interfaces;
using E_Commerce_Api.Models;
using E_Commerce_Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        EcommerceContext db;
        IJWTMangerRepository iJWTMangerRepository;
        public UsersController(EcommerceContext _db, IJWTMangerRepository _iJWTMangerRepository)
        {
            db = _db;
            iJWTMangerRepository = _iJWTMangerRepository;
        }

        [HttpGet]
        public IEnumerable<UserDetail> Get()
        {
            return db.UserDetails;
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var token = iJWTMangerRepository.Authenicate(loginViewModel, false);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel registerViewModel)
{
            LoginViewModel login = new LoginViewModel();
            login.EmailId = registerViewModel.EmailId;
            login.Password = registerViewModel.Password;
            var token = iJWTMangerRepository.Authenicate(login, true);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

    }
}
