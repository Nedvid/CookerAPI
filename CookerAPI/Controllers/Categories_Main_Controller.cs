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
    public class Categories_Main_Controller : ApiController
    {
        private CookerAPIContext db = new CookerAPIContext();

        // GET: api/Categories_Main_
        public IQueryable<Category_Main> GetCategories_Main()
        {
            return db.Categories_Main;
        }

        // GET: api/Categories_Main_/5
        [ResponseType(typeof(Category_Main))]
        public async Task<IHttpActionResult> GetCategory_Main(int id)
        {
            Category_Main category_Main = await db.Categories_Main.FindAsync(id);
            if (category_Main == null)
            {
                return NotFound();
            }

            return Ok(category_Main);
        }

        // PUT: api/Categories_Main_/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategory_Main(int id, Category_Main category_Main)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category_Main.Id_Category_Main)
            {
                return BadRequest();
            }

            db.Entry(category_Main).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Category_MainExists(id))
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

        // POST: api/Categories_Main_
        [ResponseType(typeof(Category_Main))]
        public async Task<IHttpActionResult> PostCategory_Main(Category_Main category_Main)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories_Main.Add(category_Main);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = category_Main.Id_Category_Main }, category_Main);
        }

        // DELETE: api/Categories_Main_/5
        [ResponseType(typeof(Category_Main))]
        public async Task<IHttpActionResult> DeleteCategory_Main(int id)
        {
            Category_Main category_Main = await db.Categories_Main.FindAsync(id);
            if (category_Main == null)
            {
                return NotFound();
            }

            db.Categories_Main.Remove(category_Main);
            await db.SaveChangesAsync();

            return Ok(category_Main);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Category_MainExists(int id)
        {
            return db.Categories_Main.Count(e => e.Id_Category_Main == id) > 0;
        }
    }
}