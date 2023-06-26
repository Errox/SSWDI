using Core.DomainModel;
using Core.GraphQL.ResponseTypes;
using DomainServices.Services;
using GraphQL;
using GraphQL.Client.Abstractions;
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
        private ITreatmentPlanService _treatmentPlanService;
        private IEmployeeService _employeeService;
        private readonly IGraphQLClient _client;

        public TreatmentPlanController(
            ITreatmentPlanService treatmentPlanService,
            IEmployeeService employee,
            IGraphQLClient client)
        {
            _treatmentPlanService = treatmentPlanService;
            _client = client;
            _employeeService = employee;
        }
        [Authorize(Policy = "OnlyEmployeeAndStudent")]
        // GET: TreatmentController
        public ActionResult Index()
        {
            return View(_treatmentPlanService.GetAll());
        }

        [Authorize]
        // GET: TreatmentController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            TreatmentPlan treatmentPlan = _treatmentPlanService.GetDetailedTreatmentPlan(id);

            //Fetch the Treatment containing the code
            var client = new RestClient("https://localhost:44353/api");
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
                Employee employee = _employeeService.GetEmployee(userId);

                collection.TreatmentPerformedBy = employee;

                _treatmentPlanService.AddTreatmentPlan(collection);
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
            TreatmentPlan file = _treatmentPlanService.GetTreatmentPlan(id);

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
                _treatmentPlanService.UpdateTreatmentPlan(id, collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
