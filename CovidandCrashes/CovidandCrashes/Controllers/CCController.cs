using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CovidandCrashes.Models;
using Microsoft.EntityFrameworkCore;

namespace CovidandCrashes.Controllers
{
    public class CCController : Controller
    {
        // GET: CCController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CCController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CCController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: api/<OrderController>/orders
        [Route("Covid")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CovidData>>> GetCovidData()
        {
            var context = new CCDBContext();
            return await context.Covids.Select(x => new CovidData
            {
                CovidId = x.CovidId,
                StateId = x.StateId,
                Hospitalizations = x.Hospitalization,
                Deaths = x.Deaths,
                DateId = x.DateId,

            }).ToListAsync();
        }

        // GET: api/<OrderController>/orders
        [Route("Crash")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrashData>>> GetCrashData()
        {
            var context = new CCDBContext();
            return await context.Crashtables.Select(x => new CrashData
            {
                CrashId = x.CrashId,
                DateId = x.DateId,
                StateId = x.StateId,
                CollisionId = x.CollisionId,
                IntersectionId = x.IntersectionId,
                Deaths = x.Deaths

            }).ToListAsync();
        }

        // POST: CCController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CCController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CCController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CCController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CCController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
