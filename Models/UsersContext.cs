using Microsoft.EntityFrameworkCore;

namespace UsersApi.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        { }

        public DbSet<User> Users { get;set; }
    }
}