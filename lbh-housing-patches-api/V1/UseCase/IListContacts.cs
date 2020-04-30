using lbh_housingpatches_api.V1.Boundary;

namespace lbh_housingpatches_api.V1.UseCase
{
    public interface IListContacts
    {
        
        ContactsResponse Execute(ContactsRequest contactsRequest);
    }
}