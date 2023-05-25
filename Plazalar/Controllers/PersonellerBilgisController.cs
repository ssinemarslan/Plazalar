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
    public class PersonellerBilgisController : ApiController
    {
        private PlazalarAppEntities1 db = new PlazalarAppEntities1();

        // GET: api/PersonellerBilgis
        public IQueryable<PersonellerBilgi> GetPersonellerBilgis()
        {
            return db.PersonellerBilgis;
        }

        // GET: api/PersonellerBilgis/5
        [ResponseType(typeof(PersonellerBilgi))]
        public async Task<IHttpActionResult> GetPersonellerBilgi(int id)
        {
            PersonellerBilgi personellerBilgi = await db.PersonellerBilgis.FindAsync(id);
            if (personellerBilgi == null)
            {
                return NotFound();
            }

            return Ok(personellerBilgi);
        }

        // PUT: api/PersonellerBilgis/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersonellerBilgi(int id, PersonellerBilgi personellerBilgi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personellerBilgi.PersonelNo)
            {
                return BadRequest();
            }

            db.Entry(personellerBilgi).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonellerBilgiExists(id))
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

        // POST: api/PersonellerBilgis
        [ResponseType(typeof(PersonellerBilgi))]
        public async Task<IHttpActionResult> PostPersonellerBilgi(PersonellerBilgi personellerBilgi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonellerBilgis.Add(personellerBilgi);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = personellerBilgi.PersonelNo }, personellerBilgi);
        }

        // DELETE: api/PersonellerBilgis/5
        [ResponseType(typeof(PersonellerBilgi))]
        public async Task<IHttpActionResult> DeletePersonellerBilgi(int id)
        {
            PersonellerBilgi personellerBilgi = await db.PersonellerBilgis.FindAsync(id);
            if (personellerBilgi == null)
            {
                return NotFound();
            }

            db.PersonellerBilgis.Remove(personellerBilgi);
            await db.SaveChangesAsync();

            return Ok(personellerBilgi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonellerBilgiExists(int id)
        {
            return db.PersonellerBilgis.Count(e => e.PersonelNo == id) > 0;
        }
    }
}