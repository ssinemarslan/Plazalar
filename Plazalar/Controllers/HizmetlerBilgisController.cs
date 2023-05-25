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
    public class HizmetlerBilgisController : ApiController
    {
        private PlazalarAppEntities1 db = new PlazalarAppEntities1();

        // GET: api/HizmetlerBilgis
        public IQueryable<HizmetlerBilgi> GetHizmetlerBilgis()
        {
            return db.HizmetlerBilgis;
        }

        // GET: api/HizmetlerBilgis/5
        [ResponseType(typeof(HizmetlerBilgi))]
        public async Task<IHttpActionResult> GetHizmetlerBilgi(int id)
        {
            HizmetlerBilgi hizmetlerBilgi = await db.HizmetlerBilgis.FindAsync(id);
            if (hizmetlerBilgi == null)
            {
                return NotFound();
            }

            return Ok(hizmetlerBilgi);
        }

        // PUT: api/HizmetlerBilgis/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHizmetlerBilgi(int id, HizmetlerBilgi hizmetlerBilgi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hizmetlerBilgi.HizmetNo)
            {
                return BadRequest();
            }

            db.Entry(hizmetlerBilgi).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HizmetlerBilgiExists(id))
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

        // POST: api/HizmetlerBilgis
        [ResponseType(typeof(HizmetlerBilgi))]
        public async Task<IHttpActionResult> PostHizmetlerBilgi(HizmetlerBilgi hizmetlerBilgi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HizmetlerBilgis.Add(hizmetlerBilgi);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = hizmetlerBilgi.HizmetNo }, hizmetlerBilgi);
        }

        // DELETE: api/HizmetlerBilgis/5
        [ResponseType(typeof(HizmetlerBilgi))]
        public async Task<IHttpActionResult> DeleteHizmetlerBilgi(int id)
        {
            HizmetlerBilgi hizmetlerBilgi = await db.HizmetlerBilgis.FindAsync(id);
            if (hizmetlerBilgi == null)
            {
                return NotFound();
            }

            db.HizmetlerBilgis.Remove(hizmetlerBilgi);
            await db.SaveChangesAsync();

            return Ok(hizmetlerBilgi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HizmetlerBilgiExists(int id)
        {
            return db.HizmetlerBilgis.Count(e => e.HizmetNo == id) > 0;
        }
    }
}