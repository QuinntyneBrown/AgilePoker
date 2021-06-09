using AgilePoker.Api.Models;
using AgilePoker.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgilePoker.Api.Data
{
    public class AgilePokerDbContext: DbContext, IAgilePokerDbContext
    {
        public DbSet<User> Users { get; private set; }
        public DbSet<Role> Roles { get; private set; }
        public DbSet<Story> Stories { get; private set; }
        public DbSet<ProductOwner> ProductOwners { get; private set; }
        public DbSet<Developer> Developers { get; private set; }
        public DbSet<PlanningSession> PlanningSessions { get; private set; }
        public DbSet<Invite> Invites { get; private set; }
        public AgilePokerDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgilePokerDbContext).Assembly);
        }
        
    }
}
