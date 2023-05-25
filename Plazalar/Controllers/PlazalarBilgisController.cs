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
    public class PlazalarBilgisController : ApiController
    {
        private PlazalarAppEntities1 db = new PlazalarAppEntities1();

        // GET: api/PlazalarBilgis
        public IQueryable<PlazalarBilgi> GetPlazalarBilgis()
        {
            return db.PlazalarBilgis;
        }

        // GET: api/PlazalarBilgis/5
        [ResponseType(typeof(PlazalarBilgi))]
        public async Task<IHttpActionResult> GetPlazalarBilgi(int id)
        {
            PlazalarBilgi plazalarBilgi = await db.PlazalarBilgis.FindAsync(id);
            if (plazalarBilgi == null)
            {
                return NotFound();
            }

            return Ok(plazalarBilgi);
        }

        // PUT: api/PlazalarBilgis/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPlazalarBilgi(int id, PlazalarBilgi plazalarBilgi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plazalarBilgi.PlazaNo)
            {
                return BadRequest();
            }

            db.Entry(plazalarBilgi).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlazalarBilgiExists(id))
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

        // POST: api/PlazalarBilgis
        [ResponseType(typeof(PlazalarBilgi))]
        public async Task<IHttpActionResult> PostPlazalarBilgi(PlazalarBilgi plazalarBilgi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlazalarBilgis.Add(plazalarBilgi);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = plazalarBilgi.PlazaNo }, plazalarBilgi);
        }

        // DELETE: api/PlazalarBilgis/5
        [ResponseType(typeof(PlazalarBilgi))]
        public async Task<IHttpActionResult> DeletePlazalarBilgi(int id)
        {
            PlazalarBilgi plazalarBilgi = await db.PlazalarBilgis.FindAsync(id);
            if (plazalarBilgi == null)
            {
                return NotFound();
            }

            db.PlazalarBilgis.Remove(plazalarBilgi);
            await db.SaveChangesAsync();

            return Ok(plazalarBilgi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlazalarBilgiExists(int id)
        {
            return db.PlazalarBilgis.Count(e => e.PlazaNo == id) > 0;
        }
    }
}