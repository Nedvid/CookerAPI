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
    public class Categories_Recipe_Controller : ApiController
    {
        private CookerAPIContext db = new CookerAPIContext();

        // GET: api/Categories_Recipe_
        public IQueryable<Category_Recipe> GetCategories_Recipes()
        {
            return db.Categories_Recipes;
        }

        // GET: api/Categories_Recipe_/5
        [ResponseType(typeof(Category_Recipe))]
        public async Task<IHttpActionResult> GetCategory_Recipe(int id)
        {
            Category_Recipe category_Recipe = await db.Categories_Recipes.FindAsync(id);
            if (category_Recipe == null)
            {
                return NotFound();
            }

            return Ok(category_Recipe);
        }

        // PUT: api/Categories_Recipe_/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCategory_Recipe(int id, Category_Recipe category_Recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category_Recipe.Id_Category_Recipe)
            {
                return BadRequest();
            }

            db.Entry(category_Recipe).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Category_RecipeExists(id))
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

        // POST: api/Categories_Recipe_
        [ResponseType(typeof(Category_Recipe))]
        public async Task<IHttpActionResult> PostCategory_Recipe(Category_Recipe category_Recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories_Recipes.Add(category_Recipe);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = category_Recipe.Id_Category_Recipe }, category_Recipe);
        }

        // DELETE: api/Categories_Recipe_/5
        [ResponseType(typeof(Category_Recipe))]
        public async Task<IHttpActionResult> DeleteCategory_Recipe(int id)
        {
            Category_Recipe category_Recipe = await db.Categories_Recipes.FindAsync(id);
            if (category_Recipe == null)
            {
                return NotFound();
            }

            db.Categories_Recipes.Remove(category_Recipe);
            await db.SaveChangesAsync();

            return Ok(category_Recipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Category_RecipeExists(int id)
        {
            return db.Categories_Recipes.Count(e => e.Id_Category_Recipe == id) > 0;
        }
    }
}