using IQ.Accountant.System.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IQ.Accountant.System.Repositories.IRepository
{
    public interface IUserRepository
    {
        User Login(User user);

    }
}
