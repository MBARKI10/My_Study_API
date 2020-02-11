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
    public class UpsessionsController : ApiController
    {
        private DContext db = new DContext();

        // GET: api/Upsessions
        public IQueryable<Upsession> GetUpsessions()
        {
            return db.Upsessions;
        }

        // GET: api/Upsessions/5
        [ResponseType(typeof(Upsession))]
        public async Task<IHttpActionResult> GetUpsession(int id)
        {
            Upsession upsession = await db.Upsessions.FindAsync(id);
            if (upsession == null)
            {
                return NotFound();
            }

            return Ok(upsession);
        }

        // PUT: api/Upsessions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUpsession(int id, Upsession upsession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != upsession.IdUpsession)
            {
                return BadRequest();
            }

            db.Entry(upsession).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UpsessionExists(id))
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

        // POST: api/Upsessions
        [ResponseType(typeof(Upsession))]
        public async Task<IHttpActionResult> PostUpsession(Upsession upsession)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Upsessions.Add(upsession);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = upsession.IdUpsession }, upsession);
        }

        // DELETE: api/Upsessions/5
        [ResponseType(typeof(Upsession))]
        public async Task<IHttpActionResult> DeleteUpsession(int id)
        {
            Upsession upsession = await db.Upsessions.FindAsync(id);
            if (upsession == null)
            {
                return NotFound();
            }

            db.Upsessions.Remove(upsession);
            await db.SaveChangesAsync();

            return Ok(upsession);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UpsessionExists(int id)
        {
            return db.Upsessions.Count(e => e.IdUpsession == id) > 0;
        }
    }
}