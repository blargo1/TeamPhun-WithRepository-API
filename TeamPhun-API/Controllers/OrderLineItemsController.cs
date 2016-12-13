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
    public class OrderLineItemsController : ApiController
    {
        private TeamPhunDataContext db = new TeamPhunDataContext();

        // GET: api/OrderLineItems
        public IQueryable<OrderLineItem> GetOrderLineItems()
        {
            return db.OrderLineItems;
        }

        // GET: api/OrderLineItems/5
        [ResponseType(typeof(OrderLineItem))]
        public IHttpActionResult GetOrderLineItem(int id)
        {
            OrderLineItem orderLineItem = db.OrderLineItems.Find(id);
            if (orderLineItem == null)
            {
                return NotFound();
            }

            return Ok(orderLineItem);
        }

        // PUT: api/OrderLineItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderLineItem(int id, OrderLineItem orderLineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderLineItem.OrderLineItemId)
            {
                return BadRequest();
            }

            db.Entry(orderLineItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderLineItemExists(id))
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

        // POST: api/OrderLineItems
        [ResponseType(typeof(OrderLineItem))]
        public IHttpActionResult PostOrderLineItem(OrderLineItem orderLineItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderLineItems.Add(orderLineItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orderLineItem.OrderLineItemId }, orderLineItem);
        }

        // DELETE: api/OrderLineItems/5
        [ResponseType(typeof(OrderLineItem))]
        public IHttpActionResult DeleteOrderLineItem(int id)
        {
            OrderLineItem orderLineItem = db.OrderLineItems.Find(id);
            if (orderLineItem == null)
            {
                return NotFound();
            }

            db.OrderLineItems.Remove(orderLineItem);
            db.SaveChanges();

            return Ok(orderLineItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderLineItemExists(int id)
        {
            return db.OrderLineItems.Count(e => e.OrderLineItemId == id) > 0;
        }
    }
}