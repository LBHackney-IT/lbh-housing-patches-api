

using System.ComponentModel.DataAnnotations;

namespace lbh_housingpatches_api.V1.Boundary
{
    public class ListTransactionsRequest
    {
        [Required] public string PropertyRef { get; set; }
    }
}
