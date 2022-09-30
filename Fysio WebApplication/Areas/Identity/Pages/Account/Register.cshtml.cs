using Library.core.Model;
using Library.Domain.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_WebApplication.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private IEmployeeRepository _employeeRepo;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmployeeRepository employeeRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _employeeRepo = employeeRepository;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "PhoneNumber")]
            public string PhoneNumber { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
            [Display(Name = "Sur Name")]
            public string SurName { get; set; }

            [Required]
            [Display(Name = "Worker number")]
            public int WorkerNumber { get; set; }

            [Range(1000000, 9999999, ErrorMessage = "Your Registration Number can only be 7 Numbers long. That means a number between 1000000, 9999999")]
            [Display(Name = "Registration Number")]
            public int StudentBIGNumber { get; set; }

            [Required]
            [Display(Name = "Is the user a student?")]
            public bool IsStudent { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {

            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email, PhoneNumber = Input.PhoneNumber, FirstName = Input.FirstName, SurName = Input.SurName };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // First application user. 

                    // Then create the new employee. 
                    ApplicationUser userID = _userManager.FindByNameAsync(user.UserName).Result;

                    //await userManager.AddToRoleAsync(user, "Employee"); 
                    Random rnd = new Random();
                    // Create a int with random nummer between 1000 and 9999999

                    Employee employee = new Employee();
                    employee.WorkerNumber = rnd.Next(1000, 9999999);
                    employee.FirstName = Input.FirstName;
                    employee.SurName = Input.SurName;


                    if (Input.IsStudent)
                    {
                        var addClaimResult = await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("UserType", "Student"));
                        employee.StudentNumber = Input.StudentBIGNumber;
                        employee.IsStudent = true;
                        if (!addClaimResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Student added but failed to add claim");
                        }
                    }
                    else
                    {
                        var addClaimResult = await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("UserType", "Employee"));
                        employee.IsStudent = true;
                        employee.BIGNumber = Input.StudentBIGNumber;
                        if (!addClaimResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Employee added but failed to add claim");
                        }
                    }

                    employee.ApplicationUser = userID;
                    // Save the employee 
                    _employeeRepo.AddEmployee(employee);


                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
