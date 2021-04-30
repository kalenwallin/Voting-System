using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Please select an option.")] 
        [BindProperty] 
        public string race1Vote { get; set; }

        [Required(ErrorMessage = "Please select an option.")]
        [BindProperty] 
        public string race2Vote { get; set; }

        [Required(ErrorMessage = "Please select an option.")]
        [BindProperty] 
        public string issueVote { get; set; }

        public Election election;
        public Ballot ballot;

        public void OnGet(int electionId)
        {
            election = ElectionsController.GetElection(electionId);
            ballot = BallotController.GetUserBallotFromElection(signedIn.Email, electionId);
        }

        public IActionResult OnPost()
        {
            User u = UsersController.GetUserByEmail(signedIn.Email);
            bool issueVoteBool = false;
            if(issueVote == "yes")
            {
                issueVoteBool = true;
            }
            BallotController.Create(u.UserId, 1, race1Vote, race2Vote, issueVoteBool);


            return RedirectToPage("VoteSubmitted");
        }
    }
}
