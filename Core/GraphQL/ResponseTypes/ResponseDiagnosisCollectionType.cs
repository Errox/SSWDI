using Core.ViewModels;

namespace Core.GraphQL.ResponseTypes
{
    public class ResponseDiagnosisCollectionType
    {
        public List<DiagnosisExtended> Diagnoses { get; set; }
    }
}
