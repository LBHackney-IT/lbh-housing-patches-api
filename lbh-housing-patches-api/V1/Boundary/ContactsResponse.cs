using System;
using System.Collections.Generic;
using lbh_housingpatches_api.V1.Domain;

namespace lbh_housingpatches_api.V1.Boundary
{
    public class ContactsResponse
    {
        public readonly ContactsRequest Request;
        public readonly DateTime GeneratedAt;
        public readonly List<Contact> Contacts;

        public ContactsResponse(List<Contact> contacts, ContactsRequest request, DateTime generatedAt)
        {
            Request = request;
            GeneratedAt = generatedAt;
            Contacts = contacts;
        }
    }
}
