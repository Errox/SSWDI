using Fysio_Codes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.core.Model
{
    public class DiagnosisE : Diagnosis
    {
        public string DisplayBodyAndPathology { get { return BodyLocation + " \n - " + Pathology; } }
    }
}
