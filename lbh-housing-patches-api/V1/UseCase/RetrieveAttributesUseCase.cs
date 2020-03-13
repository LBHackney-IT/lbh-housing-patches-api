using System;
using System.Collections.Generic;
using lbh_housingpatches_api.V1.UseCase;
using lbh_housingpatches_api.V1.Boundary;
using lbh_housingpatches_api.V1.Domain;
using lbh_housingpatches_api.V1.Gateways;

namespace lbh_housingpatches_api.V1.UseCase
{
    public class RetrieveAttributesUseCase : IRetrievingAttributes
    {
        private readonly IContactsGateway _contactsGateway;

        public RetrieveAttributesUseCase(IContactsGateway contactsGateway) => _contactsGateway = contactsGateway;

        public string Execute()
        {
            return _contactsGateway.GetAttributesForContactEntity();
        }
    }
}
