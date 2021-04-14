using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public IActionResult OnPostAsync()
        {
            try
            {
                //load the user from the database using Email and Password
                //User u = await LoadUser(Email, Password);
            }
            catch (Exception e)
            {
                LoginFailed = true;
                return Page();
            }
            //get the user from the database
            return RedirectToPage("Elections");
        }
    }
}
