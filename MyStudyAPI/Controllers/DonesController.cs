using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MyStudyAPI.Context;
using MyStudyAPI.Models;

namespace MyStudyAPI.Controllers
{
    public class DonesController : ApiController
    {
        private DContext db = new DContext();

        // GET: api/Dones
        public IQueryable<Done> GetDones()
        {
            return db.Dones;
        }

        // GET: api/Dones/5
        [ResponseType(typeof(Done))]
        public async Task<IHttpActionResult> GetDone(int id)
        {
            Done done = await db.Dones.FindAsync(id);
            if (done == null)
            {
                return NotFound();
            }

            return Ok(done);
        }

        // PUT: api/Dones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDone(int id, Done done)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != done.IdDone)
            {
                return BadRequest();
            }

            db.Entry(done).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoneExists(id))
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

        // POST: api/Dones
        [ResponseType(typeof(Done))]
        public async Task<IHttpActionResult> PostDone(Done done)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dones.Add(done);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DoneExists(done.IdDone))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = done.IdDone }, done);
        }

        // DELETE: api/Dones/5
        [ResponseType(typeof(Done))]
        public async Task<IHttpActionResult> DeleteDone(int id)
        {
            Done done = await db.Dones.FindAsync(id);
            if (done == null)
            {
                return NotFound();
            }

            db.Dones.Remove(done);
            await db.SaveChangesAsync();

            return Ok(done);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoneExists(int id)
        {
            return db.Dones.Count(e => e.IdDone == id) > 0;
        }
    }
}