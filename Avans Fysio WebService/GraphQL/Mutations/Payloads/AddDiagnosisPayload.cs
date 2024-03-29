﻿using Core.DomainModel;

namespace Avans_Fysio_WebService.GraphQL.Mutations.Payloads
{
    public class AddDiagnosisPayload
    {
        public AddDiagnosisPayload(Diagnosis diagnosis)
        {
            Diagnosis = diagnosis;
        }
        public Diagnosis Diagnosis { get; }
    }
}
