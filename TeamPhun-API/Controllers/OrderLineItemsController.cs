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
    public class OrderLineItemsController : ApiController
    {
        // Added 2 lines below for testing Generic Repository
        private IGenericRepository<OrderLineItem> repository = null;

        public OrderLineItemsController()

        // Added lines 26-33 below for testing Generic Repository
        {
            this.repository = new GenericRepository<OrderLineItem>();
        }

        public OrderLineItemsController(IGenericRepository<OrderLineItem> repository)
        {
            this.repository = repository;
        }
        //Comment out or remove line below
        //private TeamPhunDataContext db = new TeamPhunDataContext();

        // GET: api/OrderLineItems
        public IEnumerable<OrderLineItem> GetOrderLineItems()
        {
            return repository.SelectAll();
        }

        // GET: api/OrderLineItems/5
        [ResponseType(typeof(OrderLineItem))]
        public IHttpActionResult GetOrderLineItem(int id)
        {
            OrderLineItem orderLineItem = repository.SelectByID(id);
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

            repository.Update(orderLineItem);

            try
            {
                repository.Save();
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

            repository.Insert(orderLineItem);
            repository.Save();

            return CreatedAtRoute("DefaultApi", new { id = orderLineItem.OrderLineItemId }, orderLineItem);
        }

        // DELETE: api/OrderLineItems/5
        [ResponseType(typeof(OrderLineItem))]
        public IHttpActionResult DeleteOrderLineItem(int id)
        {
            OrderLineItem orderLineItem = repository.SelectByID(id);
            if (orderLineItem == null)
            {
                return NotFound();
            }

            repository.Delete(orderLineItem);
            repository.Save();

            return Ok(orderLineItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderLineItemExists(int id)
        {
            return repository.SelectAll().Count(e => e.OrderLineItemId == id) > 0;
        }
    }
}