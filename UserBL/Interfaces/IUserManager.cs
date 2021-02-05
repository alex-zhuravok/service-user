using System.Collections.Generic;
using System.Threading.Tasks;
using UserBL.ViewModels;

namespace UserBL.Interfaces
{
    public interface IUserManager
    {
        Task<UserVM> AddUserAsync(UserVM user);
        Task<IEnumerable<UserVM>> GetAllAsync();
    }
}