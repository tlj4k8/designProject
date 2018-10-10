using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using SaltedChefLibrary;

namespace SaltedChefApi.Controllers
{
    public class SchedulesController : ODataController
    {
        private SaltedChefEntities db = new SaltedChefEntities();

        // GET: odata/Schedules
        [EnableQuery]
        public IQueryable<Schedule> GetSchedules()
        {
            return db.Schedules;
        }

        // GET: odata/Schedules(5)
        [EnableQuery]
        public SingleResult<Schedule> GetSchedule([FromODataUri] int key)
        {
            return SingleResult.Create(db.Schedules.Where(schedule => schedule.Id == key));
        }

        // PUT: odata/Schedules(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Schedule> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Schedule schedule = db.Schedules.Find(key);
            if (schedule == null)
            {
                return NotFound();
            }

            patch.Put(schedule);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(schedule);
        }

        // POST: odata/Schedules
        public IHttpActionResult Post(Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Schedules.Add(schedule);
            db.SaveChanges();

            return Created(schedule);
        }

        // PATCH: odata/Schedules(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Schedule> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Schedule schedule = db.Schedules.Find(key);
            if (schedule == null)
            {
                return NotFound();
            }

            patch.Patch(schedule);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(schedule);
        }

        // DELETE: odata/Schedules(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Schedule schedule = db.Schedules.Find(key);
            if (schedule == null)
            {
                return NotFound();
            }

            db.Schedules.Remove(schedule);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Schedules(5)/Client
        [EnableQuery]
        public SingleResult<Client> GetClient([FromODataUri] int key)
        {
            return SingleResult.Create(db.Schedules.Where(m => m.Id == key).Select(m => m.Client));
        }

        // GET: odata/Schedules(5)/ClientMenus
        [EnableQuery]
        public IQueryable<ClientMenu> GetClientMenus([FromODataUri] int key)
        {
            return db.Schedules.Where(m => m.Id == key).SelectMany(m => m.ClientMenus);
        }

        // GET: odata/Schedules(5)/Employee
        [EnableQuery]
        public SingleResult<Employee> GetEmployee([FromODataUri] int key)
        {
            return SingleResult.Create(db.Schedules.Where(m => m.Id == key).Select(m => m.Employee));
        }

        // GET: odata/Schedules(5)/Receipts
        [EnableQuery]
        public IQueryable<Receipt> GetReceipts([FromODataUri] int key)
        {
            return db.Schedules.Where(m => m.Id == key).SelectMany(m => m.Receipts);
        }

        // GET: odata/Schedules(5)/TimeSheets
        [EnableQuery]
        public IQueryable<TimeSheet> GetTimeSheets([FromODataUri] int key)
        {
            return db.Schedules.Where(m => m.Id == key).SelectMany(m => m.TimeSheets);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScheduleExists(int key)
        {
            return db.Schedules.Count(e => e.Id == key) > 0;
        }
    }
}
