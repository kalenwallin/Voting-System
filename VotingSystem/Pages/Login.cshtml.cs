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
using VotingSystem.Controllers;

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
        [BindProperty] public bool AccountCreated { get; set; }
        public void OnGet(string key1, string accountcreated)
        {
            if(key1 != null)
            {
                SignedIn = false;
            }
            if(accountcreated != null)
            {
                AccountCreated = true;
            }
        }
        public IActionResult OnPost()
        {
            Classes.User u;
            try
            {
                //load the user from the database using Email and Password
                //User u = await LoadUser(Email, Password);
                u = UsersController.GetUserByEmail(Email);
                //validate that the user's password is correct
                if(Password != u.Password)
                {
                    throw new System.Exception();
                }
            }
            catch (Exception)
            {
                //return page and display login failed message 
                LoginFailed = true;
                return Page();
            }
            signedIn.isSignedIn = true;
            signedIn.Email = Email;
            return RedirectToPage("Elections");
        }
    }
}
