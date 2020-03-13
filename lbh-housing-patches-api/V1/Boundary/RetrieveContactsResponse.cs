using System;
using System.Collections.Generic;
using lbh_housingpatches_api.V1.Domain;

namespace lbh_housingpatches_api.V1.Boundary
{
    public class RetrieveContactsResponse
    {
        private readonly RetrieveContactsRequest Request;
        private readonly DateTime                GeneratedAt;
        private readonly List<Contact>           Contacts;

        public RetrieveContactsResponse(
            List<Contact>           contacts,
            RetrieveContactsRequest request,
            DateTime                generatedAt
        )
        {
            Request     = request;
            GeneratedAt = generatedAt;
            Contacts    = contacts;
        }
    }
}
