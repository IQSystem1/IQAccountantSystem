using IQ.Accountant.System.Entities;
using IQ.Accountant.System.Entities.DTO;
using IQ.Accountant.System.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IQAccountantSystem.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public Token Login(User user)
        {
            return _userService.Login(user);
        }
        [HttpPost("EditPassword")]
        public Token EditPassword(User user)
        {
            return _userService.EditPasssword(user);
        }
    }
}
