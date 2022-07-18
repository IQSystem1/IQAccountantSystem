using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Model;
using IQ.Accountant.System.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IQ.Accountant.System.Repositories.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly IQAccountantSystemContext _context;
        public UserRepository(IQAccountantSystemContext context)
        {
            _context = context;
        }

        public User Login(User user)
        {
            try
            {

                var userAuth = _context.users.Where(u => u.UserName== user.UserName&& u.Password == user.Password).FirstOrDefault();
                if (userAuth == null)
                {
                    return null;
                }
                return userAuth;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
