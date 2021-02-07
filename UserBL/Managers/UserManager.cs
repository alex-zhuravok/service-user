using System.Threading.Tasks;
using UserBL.Interfaces;
using UserBL.ViewModels;
using UserDataAccess;
using UserDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AutoMapper;

namespace UserBL.Managers
{
    public class UserManager: IUserManager
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public UserManager(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserVM> AddUserAsync(UserVM user)
        {
            var userToAdd = _mapper.Map<User>(user);

            await _context.Users.AddAsync(userToAdd);
            await _context.SaveChangesAsync();

            user.Id = userToAdd.Id;

            return user;
        }

        public async Task<IEnumerable<UserVM>> GetAllAsync()
        {
            return await _mapper.ProjectTo<UserVM>(_context.Users.AsQueryable())
                .ToListAsync();
        }
    }
}