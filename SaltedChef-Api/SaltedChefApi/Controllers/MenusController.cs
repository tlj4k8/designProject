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
    public class MenusController : ODataController
    {
        private SaltedChefEntities db = new SaltedChefEntities();

        // GET: odata/Menus
        [EnableQuery]
        public IQueryable<Menu> GetMenus()
        {
            return db.Menus;
        }

        // GET: odata/Menus(5)
        [EnableQuery]
        public SingleResult<Menu> GetMenu([FromODataUri] int key)
        {
            return SingleResult.Create(db.Menus.Where(menu => menu.Id == key));
        }

        // PUT: odata/Menus(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Menu> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Menu menu = db.Menus.Find(key);
            if (menu == null)
            {
                return NotFound();
            }

            patch.Put(menu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(menu);
        }

        // POST: odata/Menus
        public IHttpActionResult Post(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Menus.Add(menu);
            db.SaveChanges();

            return Created(menu);
        }

        // PATCH: odata/Menus(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Menu> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Menu menu = db.Menus.Find(key);
            if (menu == null)
            {
                return NotFound();
            }

            patch.Patch(menu);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(menu);
        }

        // DELETE: odata/Menus(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Menu menu = db.Menus.Find(key);
            if (menu == null)
            {
                return NotFound();
            }

            db.Menus.Remove(menu);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Menus(5)/ClientMenus
        [EnableQuery]
        public IQueryable<ClientMenu> GetClientMenus([FromODataUri] int key)
        {
            return db.Menus.Where(m => m.Id == key).SelectMany(m => m.ClientMenus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuExists(int key)
        {
            return db.Menus.Count(e => e.Id == key) > 0;
        }
    }
}
