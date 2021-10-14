using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Fysio_WebApplicatie.Abstract.Repositories;
using Avans_Fysio_WebApplicatie.Data;
using Avans_Fysio_WebApplicatie.Models;

namespace Avans_Fysio_WebApplicatie.DataStore
{
    public class EFTherapistsRepository : ITherapistRepository
    {
        private readonly WebApplicationDbContext _context;

        public EFTherapistsRepository(WebApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public IQueryable<Therapist> Therapists => throw new NotImplementedException();

        public IEnumerable<Therapist> FindAll()
        {
            throw new NotImplementedException();
        }

        public Therapist GetTherapist(int id)
        {
            throw new NotImplementedException();
        }

        //public IQueryable<Therapist> Therapists => _context.Therapists;
        //public IEnumerable<Therapist> FindAll()
        //{
        //    return _context.Therapists;
        //}

        //public Therapist GetTherapist(int id)
        //{
        //    return _context.Therapists.FirstOrDefault(i => i.Id == id);
        //}
    }
}
