using Library.core.Model;
using Library.core.ViewModels;
using Library.Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IPatientRepository _patientRepo;
        private IMedicalFileRepository _medicalFileRepo;
        private readonly ILogger<LoginModel> _logger;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            IEmployeeRepository employeeRepo,
            IPatientRepository patientRepo,
            ILogger<LoginModel> logger,
            IMedicalFileRepository medicalFileRepo,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _employeeRepo = employeeRepo;
            _patientRepo = patientRepo;
            _medicalFileRepo = medicalFileRepo;
            _logger = logger;
        }

        const string claimUserType = "UserType";
        Claim EmployeeUserClaim = new Claim(claimUserType, "Employee");
        Claim studentUserClaim = new Claim(claimUserType, "Student");
        Claim patientUserClaim = new Claim(claimUserType, "Patient");


        public string ReturnUrl { get; set; }
        public ViewResult Login(string returnUrl)
        {
            return base.View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);

                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user,
                        model.Password, false, false)).Succeeded)
                    {
                        var claims = await _userManager.GetClaimsAsync(user);
                        if (claims.All(subItem => claims.Any(item => item.Value.Contains("Employee"))))
                        {
                            // ALSO EMPLOYEE CHECK 
                            Console.WriteLine("Employee CHECK");
                        }
                        if (claims.All(subItem => claims.Any(item => item.Value.Contains("Student"))))
                        {
                            // ALSO EMPLOYEE CHECK 
                            Console.WriteLine("Student CHECK");
                        }
                        if (claims.All(subItem => claims.Any(item => item.Value.Contains("Patient"))))
                        {
                            // ALSO EMPLOYEE CHECK 
                            Console.WriteLine("Patient CHECK");
                        }

                        return Redirect(model?.ReturnUrl ?? "/");
                    }
                }
                ModelState.AddModelError("", "Invalid name or password");
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        [Authorize(Policy = "RequireEmployeeRole")]
        public ViewResult RegisterEmployee(string returnUrl)
        {
            return base.View(new RegisterEmployeeModel
            {
                ReturnUrl = returnUrl
            });
        }
        
        public ViewResult RegisterPatient(string returnUrl)
        {
            return base.View(new RegisterPatientModel
            {
                ReturnUrl = returnUrl
            });
        }

        [Authorize(Policy = "RequireEmployeeRole")]
        [HttpPost]
        public async Task<IActionResult> RegisterEmployee(RegisterEmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    SurName = model.SurName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,

                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    ApplicationUser newUser = _userManager.FindByNameAsync(user.UserName).Result;

                    Random rnd = new Random();
                    // Create a int with random nummer between 1000 and 9999999

                    Employee employee = new Employee
                    {
                        WorkerNumber = rnd.Next(1000, 9999999),
                        ApplicationUser = newUser
                    };

                    if (model.IsStudent)
                    {
                        employee.IsStudent = true;
                        employee.StudentNumber = model.StudentBIGNumber;
                        await _userManager.AddClaimAsync(newUser, studentUserClaim);
                    }
                    else
                    {
                        employee.IsStudent = false;
                        employee.BIGNumber = model.StudentBIGNumber;
                        await _userManager.AddClaimAsync(newUser, EmployeeUserClaim);
                    }

                    _employeeRepo.AddEmployee(employee);

                    //await _userManager.AddClaimAsync(user, EmployeeUserClaim);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatient(RegisterPatientModel model)
        {
            if (ModelState.IsValid)
            {                
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    SurName = model.SurName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                };
                
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, patientUserClaim);
                    if (!User.HasClaim("UserType", "Employee"))
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                    }


                    ApplicationUser newUser = _userManager.FindByNameAsync(user.UserName).Result;

                    // Make ID randomly generated. 
                    Random r = new Random();
                    int rInt = r.Next(100000, 999999);


                    Patient patient = new Patient
                    {
                        Gender = model.Gender,
                        DateOfBirth = model.DateOfBirth,
                        IsStudent = model.IsStudent,
                        ApplicationUser = newUser,
                        IdNumber = rInt,
                    };

                    foreach (var file in Request.Form.Files)
                    {
                        MemoryStream ms = new MemoryStream();
                        file.CopyTo(ms);
                        patient.ImgData = ms.ToArray();

                        ms.Close();
                        ms.Dispose();
                    }

                    // Check if there is a medical file with a email the same as applicationUser.Email. If so, combine it with the patient.
                    MedicalFile medicalFile = _medicalFileRepo.GetMedicalFileByEmail(model.Email);

                    if (medicalFile != null)
                    {
                        patient.MedicalFile = medicalFile;
                    }
                    
                    _patientRepo.AddPatient(patient);
                    
                    // Patient page where password and information is shown. This page can be printed for the patient to login later. 
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        public IActionResult Error() => View();

        [Authorize]
        [Route("Account/index")]
        public IActionResult AccountIndex()
        {
            // Check if user is patient. Send it to it's own page. PatientController/Details/{id}
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            // If user is student or employee. Return normal view. 
            if (User.HasClaim("UserType", "Employee") || User.HasClaim("UserType", "Student"))
            {
                return View(_employeeRepo.Employees.FirstOrDefault(i => i.EmployeeId == userId));
            }
            else
            {
                Patient patient = _patientRepo.Patients.FirstOrDefault(i => i.PatientId == userId);
                // First application user -> patient. 

                return RedirectToAction("Details", "Patient", new { id = patient.IdNumber });
            }
        }
    }
}
