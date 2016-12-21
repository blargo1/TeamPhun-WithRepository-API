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
    public class AddOnsController : ApiController
    {
        // Added 2 lines below for testing Generic Repository
        private IGenericRepository<AddOn> repository = null;

        public AddOnsController()

        // Added lines 26-33 below for testing Generic Repository
        {
            this.repository = new GenericRepository<AddOn>();
        }

        public AddOnsController(IGenericRepository<AddOn> repository)
        {
            this.repository = repository;
        }
        //Comment out or remove line below
        //private TeamPhunDataCon

        // GET: api/AddOns
        public IEnumerable<AddOn> GetAddOns()
        {
            return repository.SelectAll();
        }

        // GET: api/AddOns/5
        [ResponseType(typeof(AddOn))]
        public IHttpActionResult GetAddOn(int id)
        {
            AddOn addOn = repository.SelectByID(id);
            if (addOn == null)
            {
                return NotFound();
            }

            return Ok(addOn);
        }

        // PUT: api/AddOns/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAddOn(int id, AddOn addOn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != addOn.AddOnId)
            {
                return BadRequest();
            }

            repository.Update(addOn);

            try
            {
                repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddOnExists(id))
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

        // POST: api/AddOns
        [ResponseType(typeof(AddOn))]
        public IHttpActionResult PostAddOn(AddOn addOn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Insert(addOn);
            repository.Save();

            return CreatedAtRoute("DefaultApi", new { id = addOn.AddOnId }, addOn);
        }

        // DELETE: api/AddOns/5
        [ResponseType(typeof(AddOn))]
        public IHttpActionResult DeleteAddOn(int id)
        {
            AddOn addOn = repository.SelectByID(id);
            if (addOn == null)
            {
                return NotFound();
            }

            repository.Delete(addOn);
            repository.Save();

            return Ok(addOn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddOnExists(int id)
        {
            return repository.SelectAll().Count(e => e.AddOnId == id) > 0;
        }
    }
}