using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Classes;

namespace VotingSystem.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Autherize()
        {
            return View();
        }

        [HttpPost]

        public IActionResult create([Bind("Name,Email,Password,UserID")] User user)
        {

            return View();
        }

    }
}
