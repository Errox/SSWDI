using Fysio_Codes.Abstract;
using Fysio_Codes.DAL;
using Fysio_Codes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fysio_Codes.DataStore
{
    public class EFDiagnoseRepository : IDiagnosesRepository
    {
        private FysioCodeDbContext context;

        public EFDiagnoseRepository(FysioCodeDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Diagnosis> Diagnoses => context.Diagnoses;

        public IEnumerable<Diagnosis> FindAll()
        {
            return context.Diagnoses;
        }

        public Diagnosis GetDiagnosis(int id)
        {
            return context.Diagnoses.FirstOrDefault(i => i.Code == id);
        }
    }
}
