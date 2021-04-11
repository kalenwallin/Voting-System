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
        public IActionResult OnPostAsync()
        {
            
            //get the user from the database
            return RedirectToPage("Elections");
        }
    }
}
