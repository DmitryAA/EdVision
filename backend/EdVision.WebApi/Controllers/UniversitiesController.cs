using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EdVision.Models;
using EdVision.DataLayer;


namespace EdVision.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversitiesController : Controller
    {
        private readonly UniversityStatisticsContext db;

        public UniversitiesController(UniversityStatisticsContext db) {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<University>> GetUniversities() => Ok(db.Universities.ToList());

        [HttpGet("{id}")]
        public ActionResult<University> GetUniversity(int id) {
            University university = db.Universities.FirstOrDefault(u => u.Id == id);
            if (university == null) {
                return NotFound();
            }
            return Ok(university);
        }

        [HttpGet]
        public ActionResult<IEnumerable<University>> GetUniversities([FromQuery(Name="region_id")] int regionId) {
            Region targetRegion = db.Regions.Find(regionId);
            if (targetRegion == null) {
                return NotFound();
            }
            List<University> universities = db.Universities
                .Where(u => u.Address.City.Region == targetRegion)
                .ToList();
            return Ok(universities);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}