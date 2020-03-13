using lbh_housingpatches_api.V1.Boundary;

namespace lbh_housingpatches_api.V1.UseCase
{
    public interface IRetrievingContacts
    {
        RetrieveContactsResponse Execute(RetrieveContactsRequest request);
    }
}
