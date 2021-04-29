using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using VotingSystem.Pages.Shared;
using VotingSystem.Controllers;
using VotingSystem.Classes;

namespace VotingSystem.Pages
{
    public class ElectionsModel : PageModel
    {
        private readonly ILogger<ElectionsModel> _logger;
        public List<Election> electionList;
        public ElectionsModel(ILogger<ElectionsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            electionList = ElectionsController.GetAllElections(1);
        }
    }
}
