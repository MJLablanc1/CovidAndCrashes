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

        // GET: api/<CCController>/Covid
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

        // GET: api/<CCController>/Crash
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

        // GET: api/<CCController>/Crash
        [Route("CrashType")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CrashTypeDropdownEntry>>> GetCrashTypeData()
        {
            var context = new CCDBContext();
            return await context.Collisions.Select(x => new CrashTypeDropdownEntry
            {
                crashTypeID = x.CollisionId,
                crashTypeName = x.Collision1

            }).ToListAsync();
        }

        // GET: api/<CCController>/Crash
        [Route("Intersection")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IntersectionDropdownEntry>>> GetIntersectionData()
        {
            var context = new CCDBContext();
            return await context.Intersections.Select(x => new IntersectionDropdownEntry
            {
                intersectionTypeID = x.IntersectionId,
                intersectionTypeName = x.Intersection1

            }).ToListAsync();
        }

        // GET: api/<CCController>/State
        [Route("State")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateDropdownEntry>>> GetStateData()
        {
            var context = new CCDBContext();
            return await context.States.Select(x => new StateDropdownEntry
            {
                stateID = x.StateId,
                stateName = x.State1

            }).ToListAsync();
        }

        // GET: api/<CCController>/State
        [Route("Date")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DateDropdownEntry>>> GetDateData()
        {
            var context = new CCDBContext();
            return await context.DateTables.Select(x => new DateDropdownEntry
            {
                dateID = x.DateId,
                dateDay = x.Day,
                dateMonth = x.Month,
                dateYear = x.Year,
                dateFull = x.Day.ToString() +"/"+ x.Month.ToString() + "/" + x.Year.ToString()

            }).ToListAsync();
        }

        //// GET: api/<CCController>/Comparison
        //[Route("Comp/{date1:int}/{date2:int}/{stateId:int}/{crashId:int}")]
        //[HttpGet]
        //public async List<ComparisonTableEntry> GetCompData(int date1, int date2, int stateId, int crashID)
        //{
        //    List<ComparisonTableEntry> output = new List<ComparisonTableEntry>();

        //    var context = new CCDBContext();
        //    List<CrashData> crashData = new List<CrashData>();
        //    crashData = await context.Crashtables.Select(x => new CrashData
        //    {
        //        CrashId = x.CrashId,
        //        DateId = x.DateId,
        //        StateId = x.StateId,
        //        CollisionId = x.CollisionId,
        //        IntersectionId = x.IntersectionId,
        //        Deaths = x.Deaths

        //    }).ToListAsync();

        //    List<CovidData> covidData = new List<CovidData>();
        //    covidData = await context.Covids.Select(x => new CovidData
        //    {
        //        CovidId = x.CovidId,
        //        StateId = x.StateId,
        //        Hospitalizations = x.Hospitalization,
        //        Deaths = x.Deaths,
        //        DateId = x.DateId,

        //    }).ToListAsync();

        //    foreach (var covid in covidData)
        //    {
        //        if (covid.DateId >= date1 && covid.DateId <= date2)
        //        {
        //            if (covid.StateId == stateId)
        //            {

        //            }
        //        }
        //    }

        //}





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
