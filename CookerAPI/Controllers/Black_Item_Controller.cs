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
    public class Black_Item_Controller : ApiController
    {
        private CookerAPIContext db = new CookerAPIContext();

        // GET: api/Black_Item_
        public IQueryable<Black_Item> GetBlack_Items()
        {
            return db.Black_Items;
        }

        // GET: api/Black_Item_/5
        [ResponseType(typeof(Black_Item))]
        public async Task<IHttpActionResult> GetBlack_Item(int id)
        {
            Black_Item black_Item = await db.Black_Items.FindAsync(id);
            if (black_Item == null)
            {
                return NotFound();
            }

            return Ok(black_Item);
        }

        // PUT: api/Black_Item_/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBlack_Item(int id, Black_Item black_Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != black_Item.Id_Black_Item)
            {
                return BadRequest();
            }

            db.Entry(black_Item).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Black_ItemExists(id))
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

        // POST: api/Black_Item_
        [ResponseType(typeof(Black_Item))]
        public async Task<IHttpActionResult> PostBlack_Item(Black_Item black_Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Black_Items.Add(black_Item);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = black_Item.Id_Black_Item }, black_Item);
        }

        // DELETE: api/Black_Item_/5
        [ResponseType(typeof(Black_Item))]
        public async Task<IHttpActionResult> DeleteBlack_Item(int id)
        {
            Black_Item black_Item = await db.Black_Items.FindAsync(id);
            if (black_Item == null)
            {
                return NotFound();
            }

            db.Black_Items.Remove(black_Item);
            await db.SaveChangesAsync();

            return Ok(black_Item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Black_ItemExists(int id)
        {
            return db.Black_Items.Count(e => e.Id_Black_Item == id) > 0;
        }
    }
}