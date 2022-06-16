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
            System.Diagnostics.Debug.WriteLine("Hello");
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

        // GET: api/<CCController>/Comparison
        [Route("Comp/{date1:int}/{date2:int}/{stateId:int}/{collisionId:int}/{intersectionId:int}")]
        [HttpGet]
        public List<ComparisonTableEntry> GetCompData(int date1, int date2, int? stateId, int? collisionId, int? intersectionId)
        {
            System.Diagnostics.Debug.WriteLine("Hello");
            //http://localhost:5104/Comp/1/1/34169/3/4

            stateId = -1;

            var context = new CCDBContext();

            // Get crash deaths from CrashData WHERE stateId, collisionId, and intersectionId match (If the were given, else return all from that column)
            var crashData = from crash in context.Crashtables
                            where ( stateId != -1 ? crash.StateId == stateId : true ) 
                                && (collisionId != -1 ? crash.CollisionId == collisionId : true)
                                && (intersectionId != -1 ? crash.IntersectionId == intersectionId : true)
                            select new { crash.Deaths, crash.Date.Day, crash.Date.Month, crash.Date.Year, crash.State.State1, crash.Collision.Collision1, crash.Intersection.Intersection1 };

            var covidData = from covid in context.Covids
                            where (stateId != -1 ? covid.StateId == stateId : true)
                            select new { covid.Deaths, covid.Date.Day, covid.Date.Month, covid.Date.Year, covid.State.State1 };

            var joinedData = covidData.Join(crashData,
                                                covidDate => covidDate.Day.ToString() + covidDate.Month.ToString() + covidDate.Year.ToString(),
                                                crashDate => crashDate.Day.ToString() + crashDate.Month.ToString() + crashDate.Year.ToString(),
                                                (covidDate, crashDate) => new ComparisonTableEntry
                                                {
                                                    stateName = covidDate.State1,
                                                    crashType = crashDate.Collision1,
                                                    intersectionType = crashDate.Intersection1,
                                                    covidDeaths = covidDate.Deaths,
                                                    crashDeaths = crashDate.Deaths,
                                                    date = new DateTime(covidDate.Year, covidDate.Month, covidDate.Day)
                                                });

            List<ComparisonTableEntry> output = new List<ComparisonTableEntry>();

            try
            {
                foreach (var item in joinedData)
                {
                    if ( (date1 != -1 ? item.date >= new DateTime(2020, date1, 1) : true) && (date2 != -1 ? item.date <= new DateTime(2020, date2, 1) : true))
                    {
                        output.Add(item);
                    }
                }

            }
            catch { }

            output.Sort((a, b) => a.date.CompareTo(b.date));

            return output;

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
