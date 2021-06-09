using AgilePoker.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace AgilePoker.Api.Interfaces
{
    public interface IAgilePokerDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Role> Roles { get; }
        DbSet<Story> Stories { get; }
        DbSet<ProductOwner> ProductOwners { get; }
        DbSet<Developer> Developers { get; }
        DbSet<PlanningSession> PlanningSessions { get; }
        DbSet<Invite> Invites { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
