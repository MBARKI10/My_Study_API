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
    public class PostsController : ApiController
    {
        private DContext db = new DContext();

        // GET: api/Posts
        public IQueryable<Post> GetPosts()
        {
            
            return db.Posts.OrderByDescending(x=>x.PublishDate);
        }

        // GET: api/Posts/5
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> GetPost(int id)
        {
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

         //PUT: api/Posts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPost(int id, Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.IdPost)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> PostPost(Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //post.User = await db.Users.FindAsync(post.IdUser);

            db.Posts.Add(post);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PostExists(post.IdPost))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = post.IdPost }, post);
        }

         //DELETE: api/Posts/5
        [ResponseType(typeof(Post))]
        public async Task<IHttpActionResult> DeletePost(int id)
        {
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            foreach (PostComment comment in post.Comments.ToList())
            {
                db.PostComments.Remove(comment);
                 }
            foreach (Like like in post.Likes.ToList())
            {
                db.Likes.Remove(like);
            }
            db.Posts.Remove(post);
            await db.SaveChangesAsync();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostExists(int id)
        {
            return db.Posts.Count(e => e.IdPost == id) > 0;
        }
    }
}