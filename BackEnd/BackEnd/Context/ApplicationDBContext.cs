using BackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<itemEntity> Items { get; set; }
    }
}
