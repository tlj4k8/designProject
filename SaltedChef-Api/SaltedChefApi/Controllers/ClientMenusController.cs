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
    public class ClientMenusController : ODataController
    {
        private SaltedChefEntities db = new SaltedChefEntities();

        // GET: odata/ClientMenus
        [EnableQuery]
        public IQueryable<ClientMenu> GetClientMenus()
        {
            return db.ClientMenus;
        }

        // GET: odata/ClientMenus(5)
        [EnableQuery]
        public SingleResult<ClientMenu> GetClientMenu([FromODataUri] int key)
        {
            return SingleResult.Create(db.ClientMenus.Where(clientMenu => clientMenu.Id == key));
        }

        // PUT: odata/ClientMenus(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<ClientMenu> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClientMenu clientMenu = db.ClientMenus.Find(key);
            if (clientMenu == null)
            {
                return NotFound();
            }

            patch.Put(clientMenu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientMenuExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(clientMenu);
        }

        // POST: odata/ClientMenus
        public IHttpActionResult Post(ClientMenu clientMenu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ClientMenus.Add(clientMenu);
            db.SaveChanges();

            return Created(clientMenu);
        }

        // PATCH: odata/ClientMenus(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<ClientMenu> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ClientMenu clientMenu = db.ClientMenus.Find(key);
            if (clientMenu == null)
            {
                return NotFound();
            }

            patch.Patch(clientMenu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientMenuExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(clientMenu);
        }

        // DELETE: odata/ClientMenus(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            ClientMenu clientMenu = db.ClientMenus.Find(key);
            if (clientMenu == null)
            {
                return NotFound();
            }

            db.ClientMenus.Remove(clientMenu);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/ClientMenus(5)/Client
        [EnableQuery]
        public SingleResult<Client> GetClient([FromODataUri] int key)
        {
            return SingleResult.Create(db.ClientMenus.Where(m => m.Id == key).Select(m => m.Client));
        }

        // GET: odata/ClientMenus(5)/Menu
        [EnableQuery]
        public SingleResult<Menu> GetMenu([FromODataUri] int key)
        {
            return SingleResult.Create(db.ClientMenus.Where(m => m.Id == key).Select(m => m.Menu));
        }

        // GET: odata/ClientMenus(5)/Schedule
        [EnableQuery]
        public SingleResult<Schedule> GetSchedule([FromODataUri] int key)
        {
            return SingleResult.Create(db.ClientMenus.Where(m => m.Id == key).Select(m => m.Schedule));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientMenuExists(int key)
        {
            return db.ClientMenus.Count(e => e.Id == key) > 0;
        }
    }
}
