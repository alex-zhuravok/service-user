using System.Threading.Tasks;
using System.Linq;
using UserBL.Interfaces;
using UserBL.ViewModels;
using UserDataAccess;
using UserDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace UserBL.Managers
{
    public class UserManager: IUserManager
    {
        private readonly ApplicationContext _context;

        public UserManager(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<UserVM> AddUserAsync(UserVM user)
        {
            // TODO: Add Automapper here
            var userToAdd = new User {
                Login = user.Login,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
            };

            await _context.Users.AddAsync(userToAdd);

            await _context.SaveChangesAsync();

            user.Id = userToAdd.Id;

            return user;
        }

        public async Task<IEnumerable<UserVM>> GetAllAsync()
        {
            // TODO: Add Automapper here
            return await _context.Users
                .Select(user => new UserVM {
                    Login = user.Login,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MiddleName = user.MiddleName,
                }).ToListAsync();
        }
    }
}