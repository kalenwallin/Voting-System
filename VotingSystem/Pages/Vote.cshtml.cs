using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VotingSystem.Pages
{
    public class VoteModel : PageModel
    {
        [BindProperty] public string mayoralVote { get; set; }
        [BindProperty] public string sheriffVote { get; set; }
        [BindProperty] public string issueVote { get; set; }
        public IActionResult OnPostAsync()
        {
            
            //record user's votes to database
            return RedirectToPage("VoteSubmitted");
        }
    }
}
