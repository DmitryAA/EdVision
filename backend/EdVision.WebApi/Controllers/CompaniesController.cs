using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EdVision.Models;
using EdVision.DataLayer;

namespace EdVision.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CompaniesController : Controller
    {

        private readonly UniversityStatisticsContext db;

        public CompaniesController(UniversityStatisticsContext db) {
            this.db = db;
        }

        // GET: api/Companies
        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetCompanies() => Ok(db.Companies.ToList());

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public ActionResult<Company> GetCompany(int id) {
            Company company = db.Companies.Find(id);
            if (company == null) {
                return NotFound();
            }
            return Ok(company);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return db.Companies.Count(e => e.Id == id) > 0;
        }
    }
}