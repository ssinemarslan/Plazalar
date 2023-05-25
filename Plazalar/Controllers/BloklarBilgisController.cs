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
using Plazalar.Models;

namespace Plazalar.Controllers
{
    public class BloklarBilgisController : ApiController
    {
        private PlazalarAppEntities1 db = new PlazalarAppEntities1();

        // GET: api/BloklarBilgis
        public IQueryable<BloklarBilgi> GetBloklarBilgis()
        {
            return db.BloklarBilgis;
        }

        // GET: api/BloklarBilgis/5
        [ResponseType(typeof(BloklarBilgi))]
        public async Task<IHttpActionResult> GetBloklarBilgi(int id)
        {
            BloklarBilgi bloklarBilgi = await db.BloklarBilgis.FindAsync(id);
            if (bloklarBilgi == null)
            {
                return NotFound();
            }

            return Ok(bloklarBilgi);
        }

        // PUT: api/BloklarBilgis/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBloklarBilgi(int id, BloklarBilgi bloklarBilgi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bloklarBilgi.BlokNo)
            {
                return BadRequest();
            }

            db.Entry(bloklarBilgi).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloklarBilgiExists(id))
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

        // POST: api/BloklarBilgis
        [ResponseType(typeof(BloklarBilgi))]
        public async Task<IHttpActionResult> PostBloklarBilgi(BloklarBilgi bloklarBilgi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BloklarBilgis.Add(bloklarBilgi);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bloklarBilgi.BlokNo }, bloklarBilgi);
        }

        // DELETE: api/BloklarBilgis/5
        [ResponseType(typeof(BloklarBilgi))]
        public async Task<IHttpActionResult> DeleteBloklarBilgi(int id)
        {
            BloklarBilgi bloklarBilgi = await db.BloklarBilgis.FindAsync(id);
            if (bloklarBilgi == null)
            {
                return NotFound();
            }

            db.BloklarBilgis.Remove(bloklarBilgi);
            await db.SaveChangesAsync();

            return Ok(bloklarBilgi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BloklarBilgiExists(int id)
        {
            return db.BloklarBilgis.Count(e => e.BlokNo == id) > 0;
        }
    }
}