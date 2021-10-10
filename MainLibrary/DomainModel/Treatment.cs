using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.DomainModel
{
    public class Treatment
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool ExplanationRequired { get; set; }
    }
}
