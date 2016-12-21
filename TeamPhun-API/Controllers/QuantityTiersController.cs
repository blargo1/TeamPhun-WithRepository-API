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
    public class QuantityTiersController : ApiController
    {

        // Added 2 lines below for testing Generic Repository
        private IGenericRepository<QuantityTier> repository = null;

        public QuantityTiersController()

        // Added 7 lines  below for testing Generic Repository
        {
            this.repository = new GenericRepository<QuantityTier>();
        }
        public QuantityTiersController(IGenericRepository<QuantityTier> repository)
        {
            this.repository = repository;
        }

        //Comment out or remove line below
        //private TeamPhunDataContext db = new TeamPhunDataContext();

        // GET: api/QuantityTiers
        public IEnumerable<QuantityTier> GetQuantityTiers()
        {
            return repository.SelectAll();
        }

        // GET: api/QuantityTiers/5
        [ResponseType(typeof(QuantityTier))]
        public IHttpActionResult GetQuantityTier(int id)
        {
            QuantityTier quantityTier = repository.SelectByID(id);
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

            repository.Update(quantityTier);

            try
            {
                repository.Save();
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

            repository.Insert(quantityTier);
            repository.Save();

            return CreatedAtRoute("DefaultApi", new { id = quantityTier.QuantityTierId }, quantityTier);
        }

        // DELETE: api/QuantityTiers/5
        [ResponseType(typeof(QuantityTier))]
        public IHttpActionResult DeleteQuantityTier(int id)
        {
            QuantityTier quantityTier = repository.SelectByID(id);
            if (quantityTier == null)
            {
                return NotFound();
            }

            repository.Delete(quantityTier);
            repository.Save();

            return Ok(quantityTier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuantityTierExists(int id)
        {
            return repository.SelectAll().Count(e => e.QuantityTierId == id) > 0;
        }
    }
}