using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class DiagnosisExtended : Diagnosis
    {
        public string DisplayBodyAndPathology { get { return BodyLocation + " \n - " + Pathology; } }
    }
}
