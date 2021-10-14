using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avans_Fysio_WebApplicatie.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avans_Fysio_WebApplicatie.Abstract.Repositories
{
    public interface ITherapistRepository
    {
        IQueryable<Therapist> Therapists { get; }

        IEnumerable<Therapist> FindAll();

        Therapist GetTherapist(int id);
    }
}
