using Microsoft.EntityFrameworkCore;
using Net10_WebApi.Models;

namespace Net10_WebApi.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Villa> Villa { get; set; }
    }
}
