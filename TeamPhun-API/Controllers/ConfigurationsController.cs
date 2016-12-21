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
    public class ConfigurationsController : ApiController
    {
        // Added 2 lines below for testing Generic Repository
        private IGenericRepository<Configuration> repository = null;

        public ConfigurationsController()

        // Added lines 26-33 below for testing Generic Repository
        {
            this.repository = new GenericRepository<Configuration>();
        }

        public ConfigurationsController(IGenericRepository<Configuration> repository)
        {
            this.repository = repository;
        }
        //Comment out or remove line below
        //private TeamPhunDataContext db = new TeamPhunDataContext();

        // GET: api/Configurations
        public IEnumerable<Configuration> GetConfigurations()
        {
            return repository.SelectAll();
        }

        // GET: api/Configurations/5
        [ResponseType(typeof(Configuration))]
        public IHttpActionResult GetConfiguration(string id)
        {
            Configuration configuration = repository.SelectByID(id);
            if (configuration == null)
            {
                return NotFound();
            }

            return Ok(configuration);
        }

        // PUT: api/Configurations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutConfiguration(string id, Configuration configuration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != configuration.ConfigurationId)
            {
                return BadRequest();
            }

            repository.Update(configuration);

            try
            {
                repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigurationExists(id))
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

        // POST: api/Configurations
        [ResponseType(typeof(Configuration))]
        public IHttpActionResult PostConfiguration(Configuration configuration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Insert(configuration);

            try
            {
                repository.Save();
            }
            catch (DbUpdateException)
            {
                if (ConfigurationExists(configuration.ConfigurationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = configuration.ConfigurationId }, configuration);
        }

        // DELETE: api/Configurations/5
        [ResponseType(typeof(Configuration))]
        public IHttpActionResult DeleteConfiguration(string id)
        {
            Configuration configuration = repository.SelectByID(id);
            if (configuration == null)
            {
                return NotFound();
            }

            repository.Delete(configuration);
            repository.Save();

            return Ok(configuration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConfigurationExists(string id)
        {
            return repository.SelectAll().Count(e => e.ConfigurationId == id) > 0;
        }
    }
}