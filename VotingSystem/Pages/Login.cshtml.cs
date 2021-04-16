using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VotingSystem.Classes;

namespace VotingSystem.Pages.Shared
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [StringLength(60, MinimumLength = 8, ErrorMessage = "Email must be between 8 and 60 characters.")]
        [Required] public string Email { get; set; }

        [BindProperty]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 20 characters.")]
        [Required] public string Password { get; set; }
        [BindProperty] public bool LoginFailed { get; private set; }
        [BindProperty] public bool SignedIn { get; set; }
        public void OnGet(string key1)
        {
            if(key1 != null)
            {
                SignedIn = false;
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            User u = new Classes.User(0, Email, Password, "test", false);
            try
            {
                //load the user from the database using Email and Password
                //User u = await LoadUser(Email, Password);
            }
            catch (Exception)
            {
                LoginFailed = true;
                return Page();
            }
            signedIn.isSignedIn = true;
            //get the user from the database
            return RedirectToPage("Elections");
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            signedIn.isSignedIn = false;
            return RedirectToPage("Login");
        }
    }
}
