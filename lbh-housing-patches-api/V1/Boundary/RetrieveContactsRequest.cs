using System.ComponentModel.DataAnnotations;

namespace lbh_housingpatches_api.V1.Boundary
{
    public class RetrieveContactsRequest
    {
        [Required] public string query { get; set; }
    }
}
