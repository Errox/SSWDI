
using Avans_Fysio_WebService.ViewModels;
using System.Collections.Generic;

namespace Avans_Fysio_WebService.GraphQL.ResponseTypes
{
    public class ResponseDiagnosisCollectionType
    {
        public List<DiagnosisExtended> Diagnoses { get; set; }
    }
}
