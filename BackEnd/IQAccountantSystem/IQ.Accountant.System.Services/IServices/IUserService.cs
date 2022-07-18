
using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace IQ.Accountant.System.Services.IServices
{
    public interface IUserService
    {
        public Token Login(User user);
        public Token EditPasssword(User user);

    }
}
