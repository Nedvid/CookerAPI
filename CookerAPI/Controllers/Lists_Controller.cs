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
using CookerAPI.Models;

namespace CookerAPI.Controllers
{
    public class Lists_Controller : ApiController
    {
        private CookerAPIContext db = new CookerAPIContext();

        // GET: api/Lists_
        public IQueryable<List> GetLists()
        {
            return db.Lists;
        }

        // GET: api/Lists_/5
        [ResponseType(typeof(List))]
        public async Task<IHttpActionResult> GetList(int id)
        {
            List list = await db.Lists.FindAsync(id);
            if (list == null)
            {
                return NotFound();
            }

            return Ok(list);
        }

        // PUT: api/Lists_/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutList(int id, List list)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != list.Id_List)
            {
                return BadRequest();
            }

            db.Entry(list).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListExists(id))
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

        // POST: api/Lists_
        [ResponseType(typeof(List))]
        public async Task<IHttpActionResult> PostList(List list)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lists.Add(list);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = list.Id_List }, list);
        }

        // DELETE: api/Lists_/5
        [ResponseType(typeof(List))]
        public async Task<IHttpActionResult> DeleteList(int id)
        {
            List list = await db.Lists.FindAsync(id);
            if (list == null)
            {
                return NotFound();
            }

            db.Lists.Remove(list);
            await db.SaveChangesAsync();

            return Ok(list);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListExists(int id)
        {
            return db.Lists.Count(e => e.Id_List == id) > 0;
        }
    }
}