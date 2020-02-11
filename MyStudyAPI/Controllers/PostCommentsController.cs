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
    public class PostCommentsController : ApiController
    {
        private DContext db = new DContext();

        // GET: api/Comments
        public IQueryable<PostComment> GetComments()
        {
            return db.PostComments;
        }

        // GET: api/Comments/5
        [ResponseType(typeof(PostComment))]
        public async Task<IHttpActionResult> GetComment(string id)
        {
            PostComment comment = await db.PostComments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // PUT: api/Comments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComment(int id, PostComment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.IdComment)
            {
                return BadRequest();
            }

            db.Entry(comment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        [ResponseType(typeof(PostComment))]
        public async Task<IHttpActionResult> PostComment(PostComment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PostComments.Add(comment);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CommentExists(comment.IdComment))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = comment.IdComment }, comment);
        }

        // DELETE: api/Comments/5
        [ResponseType(typeof(PostComment))]
        public async Task<IHttpActionResult> DeleteComment(int id)
        {
            PostComment comment = await db.PostComments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            db.PostComments.Remove(comment);
            await db.SaveChangesAsync();

            return Ok(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentExists(int id)
        {
            return db.PostComments.Count(e => e.IdComment == id) > 0;
        }
    }
}