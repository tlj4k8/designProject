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
    public class TimeSheetsController : ODataController
    {
        private SaltedChefEntities db = new SaltedChefEntities();

        // GET: odata/TimeSheets
        [EnableQuery]
        public IQueryable<TimeSheet> GetTimeSheets()
        {
            return db.TimeSheets;
        }

        // GET: odata/TimeSheets(5)
        [EnableQuery]
        public SingleResult<TimeSheet> GetTimeSheet([FromODataUri] int key)
        {
            return SingleResult.Create(db.TimeSheets.Where(timeSheet => timeSheet.Id == key));
        }

        // PUT: odata/TimeSheets(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<TimeSheet> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TimeSheet timeSheet = db.TimeSheets.Find(key);
            if (timeSheet == null)
            {
                return NotFound();
            }

            patch.Put(timeSheet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeSheetExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(timeSheet);
        }

        // POST: odata/TimeSheets
        public IHttpActionResult Post(TimeSheet timeSheet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TimeSheets.Add(timeSheet);
            db.SaveChanges();

            return Created(timeSheet);
        }

        // PATCH: odata/TimeSheets(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<TimeSheet> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TimeSheet timeSheet = db.TimeSheets.Find(key);
            if (timeSheet == null)
            {
                return NotFound();
            }

            patch.Patch(timeSheet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeSheetExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(timeSheet);
        }

        // DELETE: odata/TimeSheets(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            TimeSheet timeSheet = db.TimeSheets.Find(key);
            if (timeSheet == null)
            {
                return NotFound();
            }

            db.TimeSheets.Remove(timeSheet);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/TimeSheets(5)/Schedule
        [EnableQuery]
        public SingleResult<Schedule> GetSchedule([FromODataUri] int key)
        {
            return SingleResult.Create(db.TimeSheets.Where(m => m.Id == key).Select(m => m.Schedule));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeSheetExists(int key)
        {
            return db.TimeSheets.Count(e => e.Id == key) > 0;
        }
    }
}
