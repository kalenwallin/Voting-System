using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VotingSystem.Classes;
using VotingSystem.Controllers;

namespace VotingSystem.Pages
{
    public class VoteModel : PageModel
    {
        [BindProperty] public string race1Vote { get; set; }
        [BindProperty] public string race2Vote { get; set; }
        [BindProperty] public string issueVote { get; set; }
        public Election election;

        public void OnGet(int electionId)
        {
            election = ElectionsController.GetElection(electionId);
        }

        public IActionResult OnPostAsync()
        {


            return RedirectToPage("VoteSubmitted");
        }
    }
}
