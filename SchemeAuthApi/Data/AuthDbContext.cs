using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchemeAuthApi.User.Entity;

namespace SchemeAuthApi.Data
{
    public class AuthDbContext : IdentityDbContext<UserEntity, UserRoleEntity, string>
    {
        public AuthDbContext()
        {
        }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}