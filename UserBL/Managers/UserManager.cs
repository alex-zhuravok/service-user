using UserBL.ViewModels;
using UserDataAccess;
using UserDataAccess.Entities;

namespace UserBL.Managers
{
    public class UserManager
    {
        private readonly ApplicationContext _context;

        public UserManager(ApplicationContext context)
        {
            _context = context;
        }

        public UserVM AddUser(UserVM user)
        {
            // TODO: Add Automapper here
            var userToAdd = new User {
                Login = user.Login,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MiddleName = user.MiddleName,
            };

            _context.Users.Add(userToAdd);

            _context.SaveChanges();

            user.Id = userToAdd.Id;

            return user;
        }
    }
}