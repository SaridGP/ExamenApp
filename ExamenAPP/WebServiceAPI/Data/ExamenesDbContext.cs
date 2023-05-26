using Microsoft.EntityFrameworkCore;
using WebServiceAPI.Models;

namespace WebServiceAPI.Data
{
    public class ExamenesDbContext : DbContext
    {
        public ExamenesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<tblExamen> tblExamen { get; set; }
    }
}
