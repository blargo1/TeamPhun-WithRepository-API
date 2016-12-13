using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TeamPhun_API.Models;
using TeamPhun_API.data;

namespace TeamPhun_API.Controllers
{
    public class QuantityTiersController : ApiController
    {
        private TeamPhunDataContext db = new TeamPhunDataContext();

        // GET: api/QuantityTiers
        public IQueryable<QuantityTier> GetQuantityTiers()
        {
            return db.QuantityTiers;
        }

        // GET: api/QuantityTiers/5
        [ResponseType(typeof(QuantityTier))]
        public IHttpActionResult GetQuantityTier(int id)
        {
            QuantityTier quantityTier = db.QuantityTiers.Find(id);
            if (quantityTier == null)
            {
                return NotFound();
            }

            return Ok(quantityTier);
        }

        // PUT: api/QuantityTiers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuantityTier(int id, QuantityTier quantityTier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quantityTier.QuantityTierId)
            {
                return BadRequest();
            }

            db.Entry(quantityTier).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuantityTierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/QuantityTiers
        [ResponseType(typeof(QuantityTier))]
        public IHttpActionResult PostQuantityTier(QuantityTier quantityTier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuantityTiers.Add(quantityTier);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = quantityTier.QuantityTierId }, quantityTier);
        }

        // DELETE: api/QuantityTiers/5
        [ResponseType(typeof(QuantityTier))]
        public IHttpActionResult DeleteQuantityTier(int id)
        {
            QuantityTier quantityTier = db.QuantityTiers.Find(id);
            if (quantityTier == null)
            {
                return NotFound();
            }

            db.QuantityTiers.Remove(quantityTier);
            db.SaveChanges();

            return Ok(quantityTier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuantityTierExists(int id)
        {
            return db.QuantityTiers.Count(e => e.QuantityTierId == id) > 0;
        }
    }
}