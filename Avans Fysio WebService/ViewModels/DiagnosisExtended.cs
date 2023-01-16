using Core.DomainModel;

namespace Avans_Fysio_WebService.ViewModels
{
    public class DiagnosisExtended : Diagnosis
    {
        public string DisplayBodyAndPathology { get { return BodyLocation + " \n - " + Pathology; } }
    }
}
