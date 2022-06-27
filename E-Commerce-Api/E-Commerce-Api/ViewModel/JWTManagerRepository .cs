using E_Commerce_Api.Interfaces;
using E_Commerce_Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace E_Commerce_Api.ViewModel
{
    public class JWTManagerRepository : IJWTMangerRepository
    {
        Dictionary<string, string> UserRecords;

        private readonly IConfiguration configuration;
        private readonly EcommerceContext db;

        public JWTManagerRepository(IConfiguration _configuration, EcommerceContext _db)
        {
            db = _db;
            configuration = _configuration;
        }
        public Tokens Authenicate(LoginViewModel registerViewModel, bool IsRegister)
        {
            var _isAdmin = false;
            if (IsRegister)
            {
                UserDetail user = new UserDetail();
                user.EmailId = registerViewModel.EmailId;
                user.Password = registerViewModel.Password;
                db.UserDetails.Add(user);
                db.SaveChanges();
            }
            else
            {
                _isAdmin = db.UserDetails.Any(x => x.EmailId == registerViewModel.EmailId && x.Password == registerViewModel.Password && x.IsAdmin == 1);
            }
            UserRecords = db.UserDetails.ToList().ToDictionary(x => x.EmailId, x => x.Password);
            if (!UserRecords.Any(x => x.Key == registerViewModel.EmailId && x.Value == registerViewModel.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim(ClaimTypes.Name,registerViewModel.EmailId)
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token), IsAdmin = _isAdmin };
        }
    }
}
