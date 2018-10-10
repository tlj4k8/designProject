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
    public class AvailabilitiesController : ODataController
    {
        private SaltedChefEntities db = new SaltedChefEntities();

        // GET: odata/Availabilities
        [EnableQuery]
        public IQueryable<Availability> GetAvailabilities()
        {
            return db.Availabilities;
        }

        // GET: odata/Availabilities(5)
        [EnableQuery]
        public SingleResult<Availability> GetAvailability([FromODataUri] int key)
        {
            return SingleResult.Create(db.Availabilities.Where(availability => availability.Id == key));
        }

        // PUT: odata/Availabilities(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Availability> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Availability availability = db.Availabilities.Find(key);
            if (availability == null)
            {
                return NotFound();
            }

            patch.Put(availability);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailabilityExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(availability);
        }

        // POST: odata/Availabilities
        public IHttpActionResult Post(Availability availability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Availabilities.Add(availability);
            db.SaveChanges();

            return Created(availability);
        }

        // PATCH: odata/Availabilities(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Availability> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Availability availability = db.Availabilities.Find(key);
            if (availability == null)
            {
                return NotFound();
            }

            patch.Patch(availability);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailabilityExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(availability);
        }

        // DELETE: odata/Availabilities(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Availability availability = db.Availabilities.Find(key);
            if (availability == null)
            {
                return NotFound();
            }

            db.Availabilities.Remove(availability);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Availabilities(5)/Person
        [EnableQuery]
        public SingleResult<Person> GetPerson([FromODataUri] int key)
        {
            return SingleResult.Create(db.Availabilities.Where(m => m.Id == key).Select(m => m.Person));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AvailabilityExists(int key)
        {
            return db.Availabilities.Count(e => e.Id == key) > 0;
        }
    }
}
