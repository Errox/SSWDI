using Fysio_Codes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.core.GraphQL.ResponseTypes
{
    public class ResponseTreatmentCollectionType
    {
        public List<Treatment> Treatments { get; set; }
    }
}
