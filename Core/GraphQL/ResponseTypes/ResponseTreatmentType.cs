﻿using Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.GraphQL.ResponseTypes
{
    public class ResponseTreatmentType
    {
        public Treatment treatmentByCode { get; set; }
    }
}
