using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public ActionResult<IEnumerable<University>> GetUniversities(
            [FromQuery(Name = "region_id")] int? regionId, 
            [FromQuery(Name = "city_id")] int? cityId
        ) { 
            return Ok(db.Universities.ToList()); 
        }

        [HttpGet("{id}")]
        public ActionResult<University> GetUniversity(int id) {
            University university = db.Universities.FirstOrDefault(u => u.Id == id);
            if (university == null) {
                return NotFound();
            }
            return Ok(university);
        }

        [HttpGet("{id}/departments")]
        public ActionResult<IEnumerable<Department>> GetDepartments(int id) {
            University university = db.Universities
                .Include(u => u.Departments)
                .FirstOrDefault(u => u.Id == id);
            if (university == null) {
                return NotFound();
            }
            return Ok(university.Departments);
        }

        [HttpGet("{id}/departments")]
        public ActionResult<IEnumerable<Department>> GetEducationDirection(int id) {
            University university = db.Universities
                .Include(u => u.E)
                .FirstOrDefault(u => u.Id == id);
            if (university == null) {
                return NotFound();
            }
            return Ok(university.Departments);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}