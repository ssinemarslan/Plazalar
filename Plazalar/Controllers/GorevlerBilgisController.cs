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
    public class GorevlerBilgisController : ApiController
    {
        private PlazalarAppEntities1 db = new PlazalarAppEntities1();

        // GET: api/GorevlerBilgis
        public IQueryable<GorevlerBilgi> GetGorevlerBilgis()
        {
            return db.GorevlerBilgis;
        }

        // GET: api/GorevlerBilgis/5
        [ResponseType(typeof(GorevlerBilgi))]
        public async Task<IHttpActionResult> GetGorevlerBilgi(int id)
        {
            GorevlerBilgi gorevlerBilgi = await db.GorevlerBilgis.FindAsync(id);
            if (gorevlerBilgi == null)
            {
                return NotFound();
            }

            return Ok(gorevlerBilgi);
        }

        // PUT: api/GorevlerBilgis/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGorevlerBilgi(int id, GorevlerBilgi gorevlerBilgi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gorevlerBilgi.GorevNo)
            {
                return BadRequest();
            }

            db.Entry(gorevlerBilgi).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GorevlerBilgiExists(id))
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

        // POST: api/GorevlerBilgis
        [ResponseType(typeof(GorevlerBilgi))]
        public async Task<IHttpActionResult> PostGorevlerBilgi(GorevlerBilgi gorevlerBilgi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GorevlerBilgis.Add(gorevlerBilgi);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = gorevlerBilgi.GorevNo }, gorevlerBilgi);
        }

        // DELETE: api/GorevlerBilgis/5
        [ResponseType(typeof(GorevlerBilgi))]
        public async Task<IHttpActionResult> DeleteGorevlerBilgi(int id)
        {
            GorevlerBilgi gorevlerBilgi = await db.GorevlerBilgis.FindAsync(id);
            if (gorevlerBilgi == null)
            {
                return NotFound();
            }

            db.GorevlerBilgis.Remove(gorevlerBilgi);
            await db.SaveChangesAsync();

            return Ok(gorevlerBilgi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GorevlerBilgiExists(int id)
        {
            return db.GorevlerBilgis.Count(e => e.GorevNo == id) > 0;
        }
    }
}