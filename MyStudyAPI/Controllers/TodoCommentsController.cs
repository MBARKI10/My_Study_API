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
    public class TodoCommentsController : ApiController
    {
        private DContext db = new DContext();

        // GET: api/TodoComments
        public IQueryable<TodoComment> GetTodoComments()
        {
            return db.TodoComments;
        }

        // GET: api/TodoComments/5
        [ResponseType(typeof(TodoComment))]
        public async Task<IHttpActionResult> GetTodoComment(int id)
        {
            TodoComment todoComment = await db.TodoComments.FindAsync(id);
            if (todoComment == null)
            {
                return NotFound();
            }

            return Ok(todoComment);
        }

        // PUT: api/TodoComments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTodoComment(int id, TodoComment todoComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoComment.IdComment)
            {
                return BadRequest();
            }

            db.Entry(todoComment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoCommentExists(id))
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

        // POST: api/TodoComments
        [ResponseType(typeof(TodoComment))]
        public async Task<IHttpActionResult> PostTodoComment(TodoComment todoComment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TodoComments.Add(todoComment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = todoComment.IdComment }, todoComment);
        }

        // DELETE: api/TodoComments/5
        [ResponseType(typeof(TodoComment))]
        public async Task<IHttpActionResult> DeleteTodoComment(int id)
        {
            TodoComment todoComment = await db.TodoComments.FindAsync(id);
            if (todoComment == null)
            {
                return NotFound();
            }

            db.TodoComments.Remove(todoComment);
            await db.SaveChangesAsync();

            return Ok(todoComment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoCommentExists(int id)
        {
            return db.TodoComments.Count(e => e.IdComment == id) > 0;
        }
    }
}