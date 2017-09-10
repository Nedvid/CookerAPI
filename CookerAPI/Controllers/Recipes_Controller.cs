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
    public class Recipes_Controller : ApiController
    {
        private CookerAPIContext db = new CookerAPIContext();

        // GET: api/Recipes_
        public IQueryable<Recipe> GetRecipes()
        {
            return db.Recipes;
        }

        // GET: api/Recipes_/5
        [ResponseType(typeof(Recipe))]
        public async Task<IHttpActionResult> GetRecipe(int id)
        {
            Recipe recipe = await db.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        // PUT: api/Recipes_/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRecipe(int id, Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipe.Id_Recipe)
            {
                return BadRequest();
            }

            db.Entry(recipe).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
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

        // POST: api/Recipes_
        [ResponseType(typeof(Recipe))]
        public async Task<IHttpActionResult> PostRecipe(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recipes.Add(recipe);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = recipe.Id_Recipe }, recipe);
        }

        // DELETE: api/Recipes_/5
        [ResponseType(typeof(Recipe))]
        public async Task<IHttpActionResult> DeleteRecipe(int id)
        {
            Recipe recipe = await db.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            db.Recipes.Remove(recipe);
            await db.SaveChangesAsync();

            return Ok(recipe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeExists(int id)
        {
            return db.Recipes.Count(e => e.Id_Recipe == id) > 0;
        }
    }
}