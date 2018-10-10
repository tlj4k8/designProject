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
    public class ClientNeedsController : ODataController
    {
        private SaltedChefEntities db = new SaltedChefEntities();

        // GET: odata/ClientNeeds
        [EnableQuery]
        public IQueryable<ClientNeed> GetClientNeeds()
        {
            return db.ClientNeeds;
        }

        // GET: odata/ClientNeeds(5)
        [EnableQuery]
        public SingleResult<ClientNeed> GetClientNeed([FromODataUri] int key)
        {
            return SingleResult.Create(db.ClientNeeds.Where(clientNeed => clientNeed.Id == key));
        }

        // PUT: odata/ClientNeeds(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<ClientNeed> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClientNeed clientNeed = db.ClientNeeds.Find(key);
            if (clientNeed == null)
            {
                return NotFound();
            }

            patch.Put(clientNeed);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientNeedExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(clientNeed);
        }

        // POST: odata/ClientNeeds
        public IHttpActionResult Post(ClientNeed clientNeed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientNeeds.Add(clientNeed);
            db.SaveChanges();

            return Created(clientNeed);
        }

        // PATCH: odata/ClientNeeds(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ClientNeed> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClientNeed clientNeed = db.ClientNeeds.Find(key);
            if (clientNeed == null)
            {
                return NotFound();
            }

            patch.Patch(clientNeed);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientNeedExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(clientNeed);
        }

        // DELETE: odata/ClientNeeds(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ClientNeed clientNeed = db.ClientNeeds.Find(key);
            if (clientNeed == null)
            {
                return NotFound();
            }

            db.ClientNeeds.Remove(clientNeed);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ClientNeeds(5)/Client
        [EnableQuery]
        public SingleResult<Client> GetClient([FromODataUri] int key)
        {
            return SingleResult.Create(db.ClientNeeds.Where(m => m.Id == key).Select(m => m.Client));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientNeedExists(int key)
        {
            return db.ClientNeeds.Count(e => e.Id == key) > 0;
        }
    }
}
