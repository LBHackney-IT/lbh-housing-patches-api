using Microsoft.EntityFrameworkCore;
using lbh_housingpatches_api.V1.Domain;

namespace lbh_housingpatches_api.V1.Infrastructure
{
    public interface IUHContext
    {
        DbSet<UhTransaction> UTransactions { get; set; }
    }
}
