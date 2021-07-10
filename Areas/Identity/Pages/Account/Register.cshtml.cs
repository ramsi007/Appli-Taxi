using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Appli_Taxi.Data;
using Appli_Taxi.Models;
using Appli_Taxi.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Appli_taxi.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _db = db;
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
            [Display(Name = "Mot de passe")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmer le mot de passe")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Ce champ est obligatoire")]
            [Display(Name = "Contact")]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Ce champ est obligatoire")]
            [Display(Name = "Nom")]
            public string FirstName { get; set; }


            [Required(ErrorMessage = "Ce champ est obligatoire")]
            [Display(Name = "Prénom")]
            public string LastName { get; set; }

            [Display(Name = "Nom et Prénom")]
            public string BillingName { get; set; }
            [Display(Name = "Code Postal")]
            public string BillingPostalCode { get; set; }
            [Display(Name = "Ville")]
            public string BillingCity { get; set; }
            [Display(Name = "Téléphone")]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
            public string BillingPhone { get; set; }
            [Display(Name = "Etat")]
            public string BillingState { get; set; }
            [Display(Name = "Pays")]
            public string BillingCountry { get; set; }
            [Display(Name = "Adresse")]
            public string BillingAdresse { get; set; }

            [Display(Name = "Nom et Prénom")]
            public string ShippingName { get; set; }
            [Display(Name = "Code Postal")]
            public string ShippingPostalCode { get; set; }
            [Display(Name = "Ville")]
            public string ShippingCity { get; set; }
            [Display(Name = "Teléphone")]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
            public string ShippingPhone { get; set; }
            [Display(Name = "Etat")]
            public string ShippingState { get; set; }
            [Display(Name = "Pays")]
            public string ShippingCountry { get; set; }
            [Display(Name = "Adresse")]
            public string ShippingAdresse { get; set; }

            [Display(Name = "Code Postal")]
            public string EmployeePostalCode { get; set; }
            [Display(Name = "Ville")]
            public string EmployeeCity { get; set; }
            [Display(Name = "Pays")]
            public string EmployeeCountry { get; set; }
            [Display(Name = "Adresse")]
            public string EmployeeAdresse { get; set; }

            [Display(Name = "Date de naissance")]
            public DateTime BirthDate { get; set; }

            [Display(Name = "Date d'embauche")]
            public DateTime HiringDate { get; set; }

            public string UserRole { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    PhoneNumber = Input.PhoneNumber,
                    BillingAdresse = Input.BillingAdresse,
                    BillingCity = Input.BillingCity,
                    BillingCountry = Input.BillingCountry,
                    BillingName = Input.BillingName,
                    BillingPhone = Input.BillingPhone,
                    BillingPostalCode = Input.BillingPostalCode,
                    BillingState = Input.BillingState,
                    ShippingAdresse = Input.ShippingAdresse,
                    ShippingCity = Input.ShippingCity,
                    ShippingCountry = Input.ShippingCountry,
                    ShippingName = Input.ShippingName,
                    ShippingPhone = Input.ShippingPhone,
                    ShippingPostalCode = Input.ShippingPostalCode,
                    ShippingState = Input.ShippingState,
                    EmployeeAdresse = Input.EmployeeAdresse,
                    EmployeePostalCode = Input.EmployeePostalCode,
                    EmployeeCity = Input.EmployeeCity,
                    EmployeeCountry = Input.EmployeeCountry,
                    BirthDate = Input.BirthDate,
                    HiringDate = Input.HiringDate
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {

                    //var result = await _userManager.CreateAsync(user, Input.Password);
                    //if (result.Succeeded)
                    //{
                    if (!await _roleManager.RoleExistsAsync(SD.ManagerUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.ManagerUser));
                    }

                    if (!await _roleManager.RoleExistsAsync(SD.VendorUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.VendorUser));
                    }

                    if (!await _roleManager.RoleExistsAsync(SD.CustomerUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.CustomerUser));
                    }

                    if (!await _roleManager.RoleExistsAsync(SD.EmployeeUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.EmployeeUser));
                    }

                    string role = HttpContext.Request.Form["rdUserRole"].ToString();

                    var userInDb = _db.ApplicationUsers.ToList();
                    if (userInDb.Count <= 1)
                    {
                        await _userManager.AddToRoleAsync(user, SD.ManagerUser);
                        user.UserRole = SD.ManagerUser;
                        await _db.SaveChangesAsync();
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(role))
                        {
                            await _userManager.AddToRoleAsync(user, SD.CustomerUser);
                            user.UserRole = SD.CustomerUser;
                            await _db.SaveChangesAsync();
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, role);
                            user.UserRole = role;
                            await _db.SaveChangesAsync();
                        }
                    }

                    return RedirectToAction("Index", "Users", new { area = "Admin" });
                    /*_logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    */
                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
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
