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
using Newtonsoft.Json;

namespace agile9.outlook.context.db.Controllers
{
    public class DTOReportSeries
    {
        public string name { get; set; }
        public List<double> data { get; set; }
        public List<int> years { get; set; }
    }

    public class ReportsController : ApiController
    {
        private dbContext db = new dbContext();

        // GET api/Reports
        public IQueryable<Report> GetReports()
        {
            return db.Reports;
        }

        // GET api/Reports/5
        [ResponseType(typeof(Report))]
        public async Task<IHttpActionResult> GetReport(int id)
        {
            Report report = await db.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        // GET api/Reports
        public List<DTOReportSeries> GetReports([FromUri] string mail)
        {
            var filter = "@" + mail.Split('@').Last();
            var dto = new List<DTOReportSeries>();
            var items = db.Reports.Where(x => x.Company.Email.Contains(filter));

            dto.Add(new DTOReportSeries()
            {
                name = "Expenses",
                data = items.Select(x => x.Expenses).ToList<double>(),
                years = items.Select(x => x.Year).ToList<int>()
            });
            dto.Add(new DTOReportSeries()
            {
                name = "Revenues",
                data = items.Select(x => x.Revenues).ToList<double>(),
                years = items.Select(x => x.Year).ToList<int>()
            });
            dto.Add(new DTOReportSeries()
            {
                name = "Profit",
                data = items.Select(x => x.Profit).ToList<double>(),
                years = items.Select(x => x.Year).ToList<int>()
            });
            dto.Add(new DTOReportSeries()
            {
                name = "Profit After Tax",
                data = items.Select(x => x.ProfitAfterTax).ToList<double>(),
                years = items.Select(x => x.Year).ToList<int>()
            });

            return dto;
        }

        // PUT api/Reports/5
        public async Task<IHttpActionResult> PutReport(int id, Report report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != report.Id)
            {
                return BadRequest();
            }

            db.Entry(report).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(id))
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

        // POST api/Reports
        [ResponseType(typeof(Report))]
        public async Task<IHttpActionResult> PostReport(Report report)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reports.Add(report);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = report.Id }, report);
        }

        // DELETE api/Reports/5
        [ResponseType(typeof(Report))]
        public async Task<IHttpActionResult> DeleteReport(int id)
        {
            Report report = await db.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            db.Reports.Remove(report);
            await db.SaveChangesAsync();

            return Ok(report);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReportExists(int id)
        {
            return db.Reports.Count(e => e.Id == id) > 0;
        }
    }
}