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
    public class ZipAvailabilitiesController : ODataController
    {
        private SaltedChefEntities db = new SaltedChefEntities();

        // GET: odata/ZipAvailabilities
        [EnableQuery]
        public IQueryable<ZipAvailability> GetZipAvailabilities()
        {
            return db.ZipAvailabilities;
        }

        // GET: odata/ZipAvailabilities(5)
        [EnableQuery]
        public SingleResult<ZipAvailability> GetZipAvailability([FromODataUri] int key)
        {
            return SingleResult.Create(db.ZipAvailabilities.Where(zipAvailability => zipAvailability.Id == key));
        }

        // PUT: odata/ZipAvailabilities(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<ZipAvailability> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ZipAvailability zipAvailability = db.ZipAvailabilities.Find(key);
            if (zipAvailability == null)
            {
                return NotFound();
            }

            patch.Put(zipAvailability);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZipAvailabilityExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(zipAvailability);
        }

        // POST: odata/ZipAvailabilities
        public IHttpActionResult Post(ZipAvailability zipAvailability)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ZipAvailabilities.Add(zipAvailability);
            db.SaveChanges();

            return Created(zipAvailability);
        }

        // PATCH: odata/ZipAvailabilities(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ZipAvailability> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ZipAvailability zipAvailability = db.ZipAvailabilities.Find(key);
            if (zipAvailability == null)
            {
                return NotFound();
            }

            patch.Patch(zipAvailability);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZipAvailabilityExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(zipAvailability);
        }

        // DELETE: odata/ZipAvailabilities(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ZipAvailability zipAvailability = db.ZipAvailabilities.Find(key);
            if (zipAvailability == null)
            {
                return NotFound();
            }

            db.ZipAvailabilities.Remove(zipAvailability);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ZipAvailabilities(5)/Employee
        [EnableQuery]
        public SingleResult<Employee> GetEmployee([FromODataUri] int key)
        {
            return SingleResult.Create(db.ZipAvailabilities.Where(m => m.Id == key).Select(m => m.Employee));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZipAvailabilityExists(int key)
        {
            return db.ZipAvailabilities.Count(e => e.Id == key) > 0;
        }
    }
}
