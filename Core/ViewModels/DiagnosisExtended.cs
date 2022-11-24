using Core.DomainModel;

namespace Core.ViewModels
{
    public class DiagnosisExtended : Diagnosis
    {
        public string DisplayBodyAndPathology { get { return BodyLocation + " \n - " + Pathology; } }
    }
}
