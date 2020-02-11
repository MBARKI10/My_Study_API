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
    public class HoursController : ApiController
    {
        private DContext db = new DContext();

        // GET: api/Hours
        public IQueryable<Hour> GetHours()
        {
            return db.Hours;
        }

        // GET: api/Hours/5
        [ResponseType(typeof(Hour))]
        public async Task<IHttpActionResult> GetHour(int id)
        {
            Hour hour = await db.Hours.FindAsync(id);
            if (hour == null)
            {
                return NotFound();
            }

            return Ok(hour);
        }

        // PUT: api/Hours/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHour(int id, Hour hour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hour.IdHour)
            {
                return BadRequest();
            }

            db.Entry(hour).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HourExists(id))
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

        // POST: api/Hours
        [ResponseType(typeof(Hour))]
        public async Task<IHttpActionResult> PostHour(Hour hour)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hours.Add(hour);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hour.IdHour }, hour);
        }

        // DELETE: api/Hours/5
        [ResponseType(typeof(Hour))]
        public async Task<IHttpActionResult> DeleteHour(int id)
        {
            Hour hour = await db.Hours.FindAsync(id);
            if (hour == null)
            {
                return NotFound();
            }

            db.Hours.Remove(hour);
            await db.SaveChangesAsync();

            return Ok(hour);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HourExists(int id)
        {
            return db.Hours.Count(e => e.IdHour == id) > 0;
        }
    }
}