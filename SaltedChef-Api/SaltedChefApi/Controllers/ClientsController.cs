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
    public class ClientsController : ODataController
    {
        private SaltedChefEntities db = new SaltedChefEntities();

        // GET: odata/Clients
        [EnableQuery]
        public IQueryable<Client> GetClients()
        {
            return db.Clients;
        }

        // GET: odata/Clients(5)
        [EnableQuery]
        public SingleResult<Client> GetClient([FromODataUri] int key)
        {
            return SingleResult.Create(db.Clients.Where(client => client.Id == key));
        }

        // PUT: odata/Clients(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Client> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Client client = db.Clients.Find(key);
            if (client == null)
            {
                return NotFound();
            }

            patch.Put(client);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(client);
        }

        // POST: odata/Clients
        public IHttpActionResult Post(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return Created(client);
        }

        // PATCH: odata/Clients(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Client> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Client client = db.Clients.Find(key);
            if (client == null)
            {
                return NotFound();
            }

            patch.Patch(client);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(client);
        }

        // DELETE: odata/Clients(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Client client = db.Clients.Find(key);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Clients(5)/Employee
        [EnableQuery]
        public SingleResult<Employee> GetEmployee([FromODataUri] int key)
        {
            return SingleResult.Create(db.Clients.Where(m => m.Id == key).Select(m => m.Employee));
        }

        // GET: odata/Clients(5)/Person
        [EnableQuery]
        public SingleResult<Person> GetPerson([FromODataUri] int key)
        {
            return SingleResult.Create(db.Clients.Where(m => m.Id == key).Select(m => m.Person));
        }

        // GET: odata/Clients(5)/ClientMenus
        [EnableQuery]
        public IQueryable<ClientMenu> GetClientMenus([FromODataUri] int key)
        {
            return db.Clients.Where(m => m.Id == key).SelectMany(m => m.ClientMenus);
        }

        // GET: odata/Clients(5)/ClientNeeds
        [EnableQuery]
        public IQueryable<ClientNeed> GetClientNeeds([FromODataUri] int key)
        {
            return db.Clients.Where(m => m.Id == key).SelectMany(m => m.ClientNeeds);
        }

        // GET: odata/Clients(5)/Schedules
        [EnableQuery]
        public IQueryable<Schedule> GetSchedules([FromODataUri] int key)
        {
            return db.Clients.Where(m => m.Id == key).SelectMany(m => m.Schedules);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int key)
        {
            return db.Clients.Count(e => e.Id == key) > 0;
        }
    }
}
