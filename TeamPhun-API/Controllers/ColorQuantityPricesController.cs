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
    public class ColorQuantityPricesController : ApiController
    {
        private TeamPhunDataContext db = new TeamPhunDataContext();

        // GET: api/ColorQuantityPrices
        public IQueryable<ColorQuantityPrice> GetColorQuantityPrices()
        {
            return db.ColorQuantityPrices;
        }

        // GET: api/ColorQuantityPrices/5
        [ResponseType(typeof(ColorQuantityPrice))]
        public IHttpActionResult GetColorQuantityPrice(int id)
        {
            ColorQuantityPrice colorQuantityPrice = db.ColorQuantityPrices.Find(id);
            if (colorQuantityPrice == null)
            {
                return NotFound();
            }

            return Ok(colorQuantityPrice);
        }

        // PUT: api/ColorQuantityPrices/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutColorQuantityPrice(int id, ColorQuantityPrice colorQuantityPrice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colorQuantityPrice.ColorTierId)
            {
                return BadRequest();
            }

            db.Entry(colorQuantityPrice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorQuantityPriceExists(id))
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

        // POST: api/ColorQuantityPrices
        [ResponseType(typeof(ColorQuantityPrice))]
        public IHttpActionResult PostColorQuantityPrice(ColorQuantityPrice colorQuantityPrice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ColorQuantityPrices.Add(colorQuantityPrice);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ColorQuantityPriceExists(colorQuantityPrice.ColorTierId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = colorQuantityPrice.ColorTierId }, colorQuantityPrice);
        }

        // DELETE: api/ColorQuantityPrices/5
        [ResponseType(typeof(ColorQuantityPrice))]
        public IHttpActionResult DeleteColorQuantityPrice(int id)
        {
            ColorQuantityPrice colorQuantityPrice = db.ColorQuantityPrices.Find(id);
            if (colorQuantityPrice == null)
            {
                return NotFound();
            }

            db.ColorQuantityPrices.Remove(colorQuantityPrice);
            db.SaveChanges();

            return Ok(colorQuantityPrice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorQuantityPriceExists(int id)
        {
            return db.ColorQuantityPrices.Count(e => e.ColorTierId == id) > 0;
        }
    }
}