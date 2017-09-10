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
    public class Comments_Controller : ApiController
    {
        private CookerAPIContext db = new CookerAPIContext();

        // GET: api/Comments_
        public IQueryable<Comment> GetComments()
        {
            return db.Comments;
        }

        // GET: api/Comments_/5
        [ResponseType(typeof(Comment))]
        public async Task<IHttpActionResult> GetComment(int id)
        {
            Comment comment = await db.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // PUT: api/Comments_/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComment(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.Id_Comment)
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

        // POST: api/Comments_
        [ResponseType(typeof(Comment))]
        public async Task<IHttpActionResult> PostComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Comments.Add(comment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = comment.Id_Comment }, comment);
        }

        // DELETE: api/Comments_/5
        [ResponseType(typeof(Comment))]
        public async Task<IHttpActionResult> DeleteComment(int id)
        {
            Comment comment = await db.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            db.Comments.Remove(comment);
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
            return db.Comments.Count(e => e.Id_Comment == id) > 0;
        }
    }
}