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
    public class ReceiptsController : ODataController
    {
        private SaltedChefEntities db = new SaltedChefEntities();

        // GET: odata/Receipts
        [EnableQuery]
        public IQueryable<Receipt> GetReceipts()
        {
            return db.Receipts;
        }

        // GET: odata/Receipts(5)
        [EnableQuery]
        public SingleResult<Receipt> GetReceipt([FromODataUri] int key)
        {
            return SingleResult.Create(db.Receipts.Where(receipt => receipt.Id == key));
        }

        // PUT: odata/Receipts(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Receipt> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Receipt receipt = db.Receipts.Find(key);
            if (receipt == null)
            {
                return NotFound();
            }

            patch.Put(receipt);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(receipt);
        }

        // POST: odata/Receipts
        public IHttpActionResult Post(Receipt receipt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Receipts.Add(receipt);
            db.SaveChanges();

            return Created(receipt);
        }

        // PATCH: odata/Receipts(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Receipt> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Receipt receipt = db.Receipts.Find(key);
            if (receipt == null)
            {
                return NotFound();
            }

            patch.Patch(receipt);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(receipt);
        }

        // DELETE: odata/Receipts(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Receipt receipt = db.Receipts.Find(key);
            if (receipt == null)
            {
                return NotFound();
            }

            db.Receipts.Remove(receipt);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Receipts(5)/Schedule
        [EnableQuery]
        public SingleResult<Schedule> GetSchedule([FromODataUri] int key)
        {
            return SingleResult.Create(db.Receipts.Where(m => m.Id == key).Select(m => m.Schedule));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReceiptExists(int key)
        {
            return db.Receipts.Count(e => e.Id == key) > 0;
        }
    }
}
