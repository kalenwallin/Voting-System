using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Classes;
using VotingSystem.Data;

namespace VotingSystem.Controllers
{
    public class UserController : Controller
    {

        private readonly VotingSystemContext _context;

        public UserController(VotingSystemContext context)
        {
            _context = context;
        }


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
           
            
                if (ModelState.IsValid)
                {
                    _context.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
           
            return View(user);
        }

    }
}
