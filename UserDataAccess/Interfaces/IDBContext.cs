using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserDataAccess.Entities;

namespace UserDataAccess.Interfaces
{
    public interface IDBContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}