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
    public class ParticipatesController : ApiController
    {
        private DContext db = new DContext();

        // GET: api/Participates
        public IQueryable<Participate> GetParticipates()
        {
            return db.Participates;
        }

        // GET: api/Participates/5
        [ResponseType(typeof(Participate))]
        public async Task<IHttpActionResult> GetParticipate(int id)
        {
            Participate participate = await db.Participates.FindAsync(id);
            if (participate == null)
            {
                return NotFound();
            }

            return Ok(participate);
        }

        // PUT: api/Participates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutParticipate(int id, Participate participate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != participate.IdParticipate)
            {
                return BadRequest();
            }

            db.Entry(participate).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipateExists(id))
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

        // POST: api/Participates
        [ResponseType(typeof(Participate))]
        public async Task<IHttpActionResult> PostParticipate(Participate participate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Participates.Add(participate);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ParticipateExists(participate.IdParticipate))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = participate.IdParticipate }, participate);
        }

        // DELETE: api/Participates/5
        [ResponseType(typeof(Participate))]
        public async Task<IHttpActionResult> DeleteParticipate(int id)
        {
            Participate participate = await db.Participates.FindAsync(id);
            if (participate == null)
            {
                return NotFound();
            }

            db.Participates.Remove(participate);
            await db.SaveChangesAsync();

            return Ok(participate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParticipateExists(int id)
        {
            return db.Participates.Count(e => e.IdParticipate == id) > 0;
        }
    }
}