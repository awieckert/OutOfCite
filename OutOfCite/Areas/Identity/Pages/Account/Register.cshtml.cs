using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using OutOfCite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace OutOfCite.Areas.Identity.Pages.Account {
    [AllowAnonymous]
    public class RegisterModel : PageModel {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel (
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger) {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel {
            [Required]
            [Display (Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display (Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display (Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength (100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType (DataType.Password)]
            [Display (Name = "Password")]
            public string Password { get; set; }

            [DataType (DataType.Password)]
            [Display (Name = "Confirm password")]
            [Compare ("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [Display(Name = "LinkedIn URL")]
            public string LinkedIn { get; set; }

            [Required]
            [Display(Name = "Username")]
            //[IsAvailable]
            public string UserName { get; set; }
        }

        //public class IsAvailable : ValidationAttribute
        //{
        //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //    {
        //        InputModel inputModel = (InputModel)validationContext.ObjectInstance;
                
        //        var checkUserName = _userManager.Users.Where(x => x.UserName.ToLower() == inputModel.UserName.ToLower()).Count();

        //        return base.IsValid(value, validationContext);
        //    }
        //}

        public void OnGet (string returnUrl = null) {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync (string returnUrl = null) {
            returnUrl = returnUrl ?? Url.Content ("~/Home/MainPage");
            if (ModelState.IsValid) {
                var user = new ApplicationUser {
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    UserName = Input.UserName,
                    Email = Input.Email,
                    LinkedIn = Input.LinkedIn
                };
                // Need to check the number of returned applications users. If it is 0 then we are good to go
                // otherwise need to return to the page and display an erro. May want to use a custom validation

                var checkUserName = _userManager.Users.Where(x => x.UserName.ToLower() == user.UserName.ToLower()).Count();

                if (checkUserName != 0)
                {
                    return Page();
                }

                var result = await _userManager.CreateAsync (user, Input.Password);
                if (result.Succeeded) {
                    _logger.LogInformation ("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync (user);
                    var callbackUrl = Url.Page (
                        "/Account/ConfirmEmail",
                        pageHandler : null,
                        values : new { userId = user.Id, code = code },
                        protocol : Request.Scheme);

                    await _signInManager.SignInAsync (user, isPersistent : false);
                    return LocalRedirect (returnUrl);
                }
                foreach (var error in result.Errors) {
                    ModelState.AddModelError (string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page ();
        }
    }
}