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
    public class CustomersController : ApiController
    {
        // Added 2 lines below for testing Generic Repository
        private IGenericRepository<Customer> repository = null;

        public CustomersController()

        // Added lines 26-33 below for testing Generic Repository
        {
            this.repository = new GenericRepository<Customer>();
        }

        public CustomersController(IGenericRepository<Customer> repository)
        {
            this.repository = repository;
        }
        //Comment out or remove line below
        //private TeamPhunDataContext db = new TeamPhunDataContext();

        // GET: api/Customers
        public IEnumerable<Customer> GetCustomers()
        {
            return repository.SelectAll();
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = repository.SelectByID(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            repository.Update(customer);

            try
            {
                repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Insert(customer);
            repository.Save();

            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = repository.SelectByID(id);
            if (customer == null)
            {
                return NotFound();
            }

            repository.Delete(customer);
            repository.Save();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return repository.SelectAll().Count(e => e.CustomerId == id) > 0;
        }
    }
}