 using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private BowlersDbContext _context { get; set; }

        public HomeController(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index(string teamName)
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamName"];

            var bowlers = _context.Bowlers
                .Include("Team")
                .Where(x => x.Team.TeamName == teamName || teamName == null)
                .ToList(); //join the other dataset using the .include here.

            return View(bowlers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("EditBowler");
        }

        [HttpPost]
        public IActionResult Add(Bowler bowler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bowler);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("EditBowler", bowler); 
        }

        [HttpPost]
        public IActionResult Edit(Bowler bowler)
        {
            _context.Bowlers.Update(bowler);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerid);

            return View("Delete", bowler);
        }

        [HttpPost]
        public IActionResult Delete(Bowler bowler)
        {
            var bowldelete = _context.Bowlers.Single(x => x.BowlerID == bowler.BowlerID);
            _context.Bowlers.Remove(bowldelete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
