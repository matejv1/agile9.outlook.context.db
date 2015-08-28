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
using agile9.outlook.context.db.Models;

namespace agile9.outlook.context.db.Controllers
{
    public class InsurancesController : ApiController
    {
        private dbContext db = new dbContext();

        // GET: api/Insurances
        public IQueryable<Insurance> GetInsurances()
        {
            return db.Insurances;
        }

        // GET: api/Insurances/5
        [ResponseType(typeof(Insurance))]
        public async Task<IHttpActionResult> GetInsurance(int id)
        {
            Insurance insurance = await db.Insurances.FindAsync(id);
            if (insurance == null)
            {
                return NotFound();
            }

            return Ok(insurance);
        }

        // PUT: api/Insurances/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInsurance(int id, Insurance insurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insurance.Id)
            {
                return BadRequest();
            }

            db.Entry(insurance).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceExists(id))
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

        // POST: api/Insurances
        [ResponseType(typeof(Insurance))]
        public async Task<IHttpActionResult> PostInsurance(Insurance insurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insurances.Add(insurance);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = insurance.Id }, insurance);
        }

        // DELETE: api/Insurances/5
        [ResponseType(typeof(Insurance))]
        public async Task<IHttpActionResult> DeleteInsurance(int id)
        {
            Insurance insurance = await db.Insurances.FindAsync(id);
            if (insurance == null)
            {
                return NotFound();
            }

            db.Insurances.Remove(insurance);
            await db.SaveChangesAsync();

            return Ok(insurance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InsuranceExists(int id)
        {
            return db.Insurances.Count(e => e.Id == id) > 0;
        }
    }
}