using Microsoft.EntityFrameworkCore;
using Refund.API.Data.Entities;

namespace Refund.API.Data
{
    public class RefundDbContext : DbContext
    {
        public RefundDbContext(DbContextOptions<RefundDbContext> options) : base(options) { }

        public DbSet<CancellationRequest> CancellationRequests { get; set; }
    }
}
