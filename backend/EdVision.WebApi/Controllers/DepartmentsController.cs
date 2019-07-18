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
    public class DepartmentsController : Controller
    {
        private readonly UniversityStatisticsContext db;

        public DepartmentsController(UniversityStatisticsContext db) {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetDepartments() => Ok(db.Departments.ToList());

        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartment(int id) {
            Department department = db.Departments.Find(id);
            if (department == null) {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetDepartments([FromQuery(Name = "university_id")] int universityId) {
            University university = db.Universities.Find(universityId);
            if (university == null) {
                return NotFound();
            }
            return Ok(university.Departments.ToList());
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}