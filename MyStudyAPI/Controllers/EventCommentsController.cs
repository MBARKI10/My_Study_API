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
    public class EventCommentsController : ApiController
    {
        private DContext db = new DContext();

        // GET: api/EventComments
        public IQueryable<EventComment> GetEventComments()
        {
            return db.EventComments;
        }

        // GET: api/EventComments/5
        [ResponseType(typeof(EventComment))]
        public async Task<IHttpActionResult> GetEventComment(int id)
        {
            EventComment eventComment = await db.EventComments.FindAsync(id);
            if (eventComment == null)
            {
                return NotFound();
            }

            return Ok(eventComment);
        }

        // PUT: api/EventComments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventComment(int id, EventComment eventComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventComment.IdComment)
            {
                return BadRequest();
            }

            db.Entry(eventComment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventCommentExists(id))
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

        // POST: api/EventComments
        [ResponseType(typeof(EventComment))]
        public async Task<IHttpActionResult> PostEventComment(EventComment eventComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventComments.Add(eventComment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eventComment.IdComment }, eventComment);
        }

        // DELETE: api/EventComments/5
        [ResponseType(typeof(EventComment))]
        public async Task<IHttpActionResult> DeleteEventComment(int id)
        {
            EventComment eventComment = await db.EventComments.FindAsync(id);
            if (eventComment == null)
            {
                return NotFound();
            }

            db.EventComments.Remove(eventComment);
            await db.SaveChangesAsync();

            return Ok(eventComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventCommentExists(int id)
        {
            return db.EventComments.Count(e => e.IdComment == id) > 0;
        }
    }
}