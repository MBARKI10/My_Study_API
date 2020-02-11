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
    public class SubgroupsController : ApiController
    {
        private DContext db = new DContext();

        private SubgroupRepository repository = null;

        public SubgroupsController()
        {
            this.repository = new SubgroupRepository();
        }

         // GET: api/Subgroups
        public IQueryable<Subgroup> GetSubgroups()
        {
            return db.Subgroups;
        }
         //public ICollection<string> GetSubgroups()
         //{
         //    return this.repository.getSubgroupsLabel();
         //}

        // GET: api/Subgroups/5
        [ResponseType(typeof(Subgroup))]
        public async Task<IHttpActionResult> GetSubgroup(int id)
        {
            Subgroup subgroup = await db.Subgroups.FindAsync(id);
            if (subgroup == null)
            {
                return NotFound();
            }

            return Ok(subgroup);
        }

        // PUT: api/Subgroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubgroup(int id, Subgroup subgroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subgroup.IdSubgroup)
            {
                return BadRequest();
            }

            db.Entry(subgroup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubgroupExists(id))
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

        // POST: api/Subgroups
        [ResponseType(typeof(Subgroup))]
        public async Task<IHttpActionResult> PostSubgroup(Subgroup subgroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subgroups.Add(subgroup);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subgroup.IdSubgroup }, subgroup);
        }

        // DELETE: api/Subgroups/5
        [ResponseType(typeof(Subgroup))]
        public async Task<IHttpActionResult> DeleteSubgroup(int id)
        {
            Subgroup subgroup = await db.Subgroups.FindAsync(id);
            if (subgroup == null)
            {
                return NotFound();
            }

            db.Subgroups.Remove(subgroup);
            await db.SaveChangesAsync();

            return Ok(subgroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubgroupExists(int id)
        {
            return db.Subgroups.Count(e => e.IdSubgroup == id) > 0;
        }
    }
}