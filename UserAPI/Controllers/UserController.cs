using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserBL.Interfaces;
using UserBL.ViewModels;
using UserDataAccess;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserManager _userManager;

        public UserController(ILogger<UserController> logger,
            IUserManager userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IEnumerable<UserVM>> GetAll()
        {
            return await _userManager.GetAllAsync();
        }

        [HttpPost]
        public async Task AddUser(UserVM user)
        {
            await _userManager.AddUserAsync(user);
        }
    }
}
