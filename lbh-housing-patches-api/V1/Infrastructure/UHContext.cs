using Microsoft.EntityFrameworkCore;
using lbh_housingpatches_api.V1.Domain;

namespace lbh_housingpatches_api.V1.Infrastructure
{
    public class UhContext : DbContext, IUHContext
    {
        public UhContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UhTransaction> UTransactions { get; set; }
    }
}
