using Core.DomainModel;
using System.Collections.Generic;

namespace Core.GraphQL.ResponseTypes
{
    public class ResponseTreatmentCollectionType
    {
        public List<Treatment> Treatments { get; set; }
    }
}
