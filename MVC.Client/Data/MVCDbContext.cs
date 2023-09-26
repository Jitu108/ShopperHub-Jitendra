using Microsoft.EntityFrameworkCore;
using MVC.Client.Models;

namespace MVC.Client.Data
{
    public class MVCDbContext  :DbContext
    {
        public MVCDbContext(DbContextOptions<MVCDbContext> options): base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
