using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using IQ.Accountant.System.Repositories.IRepository;
using IQ.Accountant.System.Services.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace IQ.Accountant.System.Services.Services
{
    public class UserService:IUserService
    {

        private IUserRepository _userRepository;
        private IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public Token Login(User user)
        {
            user.Password = HashPassword(user.Password);
            var userAuth = _userRepository.Login(user);
            
            if (userAuth == null)
                return null;
            else
            {
                return GetToken(userAuth);
            }
        }
        public Token GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
                new Claim("username",user.UserName),
                new Claim("userId", user.Id.ToString()),
              }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Token()
            {
                token = tokenHandler.WriteToken(token),
                
            };

        }

        public Token EditPasssword(User user)
        {
            user.Password = HashPassword(user.Password);
            var userAuth = _userRepository.Login(user);

            if (userAuth == null)
                return null;
            else
            {
                return GetToken(userAuth);
            }
        }

        private string HashPassword(string pass)
        {
            HashAlgorithm algorithm = new SHA256CryptoServiceProvider();
            Byte[] inputBytes = Encoding.UTF8.GetBytes(pass);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
