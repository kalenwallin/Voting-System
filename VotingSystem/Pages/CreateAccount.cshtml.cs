using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VotingSystem.Classes;
using VotingSystem.Controllers;

namespace VotingSystem.Pages.Shared
{
    public class CreateAccountModel : PageModel
    {
        [BindProperty]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Full Name must be between 5 and 60 characters.")]
        [Required] public string Name { get; set; }

        [BindProperty]
        [StringLength(60, MinimumLength = 8, ErrorMessage = "Email must be between 8 and 60 characters.")]
        [Required] public string Email { get; set; }

        [BindProperty]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 20 characters.")]
        [Required] public string Password { get; set; }

        [BindProperty]
        [Compare("Password", ErrorMessage = "Retype password doesn't match, Type again!")]
        [Required] public string RetypePassword { get; set; }

        [BindProperty] public bool CreateAccountFailed { get; private set; }

        public IActionResult OnPostAsync()
        {
            try
            {
                //insert the user into the database
                UsersController.Create(Email, Password, Name);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                CreateAccountFailed = true;
                return Page();
            }

            //send the user to the database
            return RedirectToPage("Login");
        }
    }
}
