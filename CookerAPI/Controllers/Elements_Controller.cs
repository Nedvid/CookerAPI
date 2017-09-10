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
    public class Elements_Controller : ApiController
    {
        private CookerAPIContext db = new CookerAPIContext();

        // GET: api/Elements_
        public IQueryable<Element> GetElements()
        {
            return db.Elements;
        }

        // GET: api/Elements_/5
        [ResponseType(typeof(Element))]
        public async Task<IHttpActionResult> GetElement(int id)
        {
            Element element = await db.Elements.FindAsync(id);
            if (element == null)
            {
                return NotFound();
            }

            return Ok(element);
        }

        // PUT: api/Elements_/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutElement(int id, Element element)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != element.Id_Element)
            {
                return BadRequest();
            }

            db.Entry(element).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementExists(id))
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

        // POST: api/Elements_
        [ResponseType(typeof(Element))]
        public async Task<IHttpActionResult> PostElement(Element element)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Elements.Add(element);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = element.Id_Element }, element);
        }

        // DELETE: api/Elements_/5
        [ResponseType(typeof(Element))]
        public async Task<IHttpActionResult> DeleteElement(int id)
        {
            Element element = await db.Elements.FindAsync(id);
            if (element == null)
            {
                return NotFound();
            }

            db.Elements.Remove(element);
            await db.SaveChangesAsync();

            return Ok(element);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ElementExists(int id)
        {
            return db.Elements.Count(e => e.Id_Element == id) > 0;
        }
    }
}