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
    public class ColorTiersController : ApiController
    {
        private TeamPhunDataContext db = new TeamPhunDataContext();

        // GET: api/ColorTiers
        public IQueryable<ColorTier> GetColorTiers()
        {
            return db.ColorTiers;
        }

        // GET: api/ColorTiers/5
        [ResponseType(typeof(ColorTier))]
        public IHttpActionResult GetColorTier(int id)
        {
            ColorTier colorTier = db.ColorTiers.Find(id);
            if (colorTier == null)
            {
                return NotFound();
            }

            return Ok(colorTier);
        }

        // PUT: api/ColorTiers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutColorTier(int id, ColorTier colorTier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colorTier.ColorTierId)
            {
                return BadRequest();
            }

            db.Entry(colorTier).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorTierExists(id))
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

        // POST: api/ColorTiers
        [ResponseType(typeof(ColorTier))]
        public IHttpActionResult PostColorTier(ColorTier colorTier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ColorTiers.Add(colorTier);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = colorTier.ColorTierId }, colorTier);
        }

        // DELETE: api/ColorTiers/5
        [ResponseType(typeof(ColorTier))]
        public IHttpActionResult DeleteColorTier(int id)
        {
            ColorTier colorTier = db.ColorTiers.Find(id);
            if (colorTier == null)
            {
                return NotFound();
            }

            db.ColorTiers.Remove(colorTier);
            db.SaveChanges();

            return Ok(colorTier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorTierExists(int id)
        {
            return db.ColorTiers.Count(e => e.ColorTierId == id) > 0;
        }
    }
}