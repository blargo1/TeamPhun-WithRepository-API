using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using TeamPhun_API.Models;
using TeamPhun_API.data;
using TeamPhun_API.Repository;
using System.Collections.Generic;

namespace TeamPhun_API.Controllers
{
    public class ColorTiersController : ApiController
    {
        // Added 2 lines below for testing Generic Repository
        private IGenericRepository<ColorTier> repository = null;

        public ColorTiersController()

        // Added lines 26-33 below for testing Generic Repository
        {
            this.repository = new GenericRepository<ColorTier>();
        }

        public ColorTiersController(IGenericRepository<ColorTier> repository)
        {
            this.repository = repository;
        }
        //Comment out or remove line below
        //private TeamPhunDataContext db = new TeamPhunDataContext();

        // GET: api/ColorTiers
        public IEnumerable<ColorTier> GetColorTiers()
        {
            return repository.SelectAll();
        }

        // GET: api/ColorTiers/5
        [ResponseType(typeof(ColorTier))]
        public IHttpActionResult GetColorTier(int id)
        {
            ColorTier colorTier = repository.SelectByID(id);
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

            repository.Update(colorTier);

            try
            {
                repository.Save();
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

            repository.Insert(colorTier);
            repository.Save();

            return CreatedAtRoute("DefaultApi", new { id = colorTier.ColorTierId }, colorTier);
        }

        // DELETE: api/ColorTiers/5
        [ResponseType(typeof(ColorTier))]
        public IHttpActionResult DeleteColorTier(int id)
        {
            ColorTier colorTier = repository.SelectByID(id);
            if (colorTier == null)
            {
                return NotFound();
            }

            repository.Delete(colorTier);
            repository.Save();

            return Ok(colorTier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColorTierExists(int id)
        {
            return repository.SelectAll().Count(e => e.ColorTierId == id) > 0;
        }
    }
}