using Core.DomainModel;
using GraphQL;
using GraphQL.Client.Abstractions;
using Library.core.GraphQL.ResponseTypes;
using Core.DomainModel;
using DomainServices.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Controllers
{
    [Authorize]
    public class TreatmentPlanController : Controller
    {
        private ITreatmentPlanRepository _treatmentPlanRepo;
        private IEmployeeRepository _employeeRepo;
        private readonly IGraphQLClient _client;

        public TreatmentPlanController(
            ITreatmentPlanRepository treatmentPlanRepo, 
            IEmployeeRepository employee,
            IGraphQLClient client)
        {
            _treatmentPlanRepo = treatmentPlanRepo;
            _client = client;
            _employeeRepo = employee;
        }
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: TreatmentController
        public ActionResult Index()
        {
            return View(_treatmentPlanRepo.FindAll());
        }

        [Authorize]
        // GET: TreatmentController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            TreatmentPlan treatmentPlan = _treatmentPlanRepo.TreatmentPlans
                .Include(c1 => c1.PracticeRoom)
                .Include(c1 => c1.TreatmentPerformedBy)
                    .ThenInclude(a => a.ApplicationUser)
                .FirstOrDefault(i => i.Id == id);

            //Fetch the Treatment containing the code
            var client = new RestClient("https://fysiowebservice.azurewebsites.net/api");
            var request = new RestRequest("/Treatment/" + treatmentPlan.Type, Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            Treatment treatment = JsonConvert.DeserializeObject<Treatment>(response.Content);
            //Send them towards the viewbag             

            ViewBag.Description = treatment.Description;
            ViewBag.ExplanationRequired = treatment.ExplanationRequired;

            return View(treatmentPlan);
        }

        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: TreatmentController/Create
        public async Task<ActionResult> Create()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                query GetAllTreat{
                  treatments {
                    code
                    description
                  }
                }"
            };

            var response = await _client.SendQueryAsync<ResponseTreatmentCollectionType>(query);

            SelectList selectlist = new SelectList(response.Data.Treatments, "Code", "Description");

            ViewBag.Treatments = selectlist;
            return View();
        }

        // POST: TreatmentController/Create
        [HttpPost]
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TreatmentPlan collection)
        {
            try
            {
                string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Employee employee = _employeeRepo.Employees.FirstOrDefault(i => i.Id.ToString() == userId);

                collection.TreatmentPerformedBy = employee;

                _treatmentPlanRepo.AddTreatmentPlan(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TreatmentController/Edit/5
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        public async Task<ActionResult> EditAsync(int id)
        {
            TreatmentPlan file = _treatmentPlanRepo.GetTreatmentPlan(id);
            
            var query = new GraphQLRequest
            {
                Query = @"
                query GetAllTreat{
                  treatments {
                    code
                    description
                  }
                }"
            };

            var response = await _client.SendQueryAsync<ResponseTreatmentCollectionType>(query);

            SelectList selectlist = new SelectList(response.Data.Treatments, "Code", "Description");

            var selected = selectlist.Where(x => x.Value == file.Type.ToString()).First();
            selected.Selected = true;

            ViewBag.Treatments = selectlist;
            return View(file);
        }

        // POST: TreatmentController/Edit/5
        [HttpPost]
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TreatmentPlan collection)
        {
            try
            {
                _treatmentPlanRepo.UpdateTreatmentPlan(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
