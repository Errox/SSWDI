using Core.DomainModel;
using Core.ViewModels;
using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.GraphQL.ResponseTypes
{
    public class ResponseDiagnosisCollectionType
    {
        public List<DiagnosisExtended> Diagnoses { get; set; }
    }
}
