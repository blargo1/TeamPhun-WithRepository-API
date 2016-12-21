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
using TeamPhun_API.Repository;

namespace TeamPhun_API.Controllers
{
    public class ColorQuantityPricesController : ApiController
    {
        // Added 2 lines below for testing Generic Repository
        private IGenericRepository<ColorQuantityPrice> repository = null;

        public ColorQuantityPricesController()

        // Added lines 26-33 below for testing Generic Repository
        {
            this.repository = new GenericRepository<ColorQuantityPrice>();
        }

        public ColorQuantityPricesController(IGenericRepository<ColorQuantityPrice> repository)
        {
            this.repository = repository;
        }
        //Comment out or remove line below(private TeamPhunDataContext db = new TeamPhunDataContext();)
        //private TeamPhunDataContext db = new TeamPhunDataContext();

        // GET: api/ColorQuantityPrices
        public IEnumerable<ColorQuantityPrice> GetColorQuantityPrices()
        {
            return repository.SelectAll();
        }

        // GET: api/ColorQuantityPrices/5
        [ResponseType(typeof(ColorQuantityPrice))]
        public IHttpActionResult GetColorQuantityPrice(int id)
        {
            ColorQuantityPrice colorQuantityPrice = repository.SelectByID(id);
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

            repository.Update(colorQuantityPrice);

            try
            {
                repository.Save();
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

            repository.Insert(colorQuantityPrice);

            try
            {
                repository.Save();
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
            ColorQuantityPrice colorQuantityPrice = repository.SelectByID(id);
            if (colorQuantityPrice == null)
            {
                return NotFound();
            }

            repository.Delete(colorQuantityPrice);
            repository.Save();

            return Ok(colorQuantityPrice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorQuantityPriceExists(int id)
        {
            return repository.SelectAll().Count(e => e.ColorTierId == id) > 0;
        }
    }
}