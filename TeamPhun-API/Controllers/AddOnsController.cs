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
    public class AddOnsController : ApiController
    {
        private TeamPhunDataContext db = new TeamPhunDataContext();

        // GET: api/AddOns
        public IQueryable<AddOn> GetAddOns()
        {
            return db.AddOns;
        }

        // GET: api/AddOns/5
        [ResponseType(typeof(AddOn))]
        public IHttpActionResult GetAddOn(int id)
        {
            AddOn addOn = db.AddOns.Find(id);
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

            db.Entry(addOn).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
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

            db.AddOns.Add(addOn);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = addOn.AddOnId }, addOn);
        }

        // DELETE: api/AddOns/5
        [ResponseType(typeof(AddOn))]
        public IHttpActionResult DeleteAddOn(int id)
        {
            AddOn addOn = db.AddOns.Find(id);
            if (addOn == null)
            {
                return NotFound();
            }

            db.AddOns.Remove(addOn);
            db.SaveChanges();

            return Ok(addOn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddOnExists(int id)
        {
            return db.AddOns.Count(e => e.AddOnId == id) > 0;
        }
    }
}