using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EdVision.WebApi.Model;

namespace EdVision.WebApi.Controllers
{
    [RoutePrefix("api/departments")]
    public class DepartmentsController : ApiController
    {
        private MentoringContext db = new MentoringContext();

        // GET: api/Departments
        [HttpGet]
        [Route("")]
        public IEnumerable<object> GetDepartments()
        {
            var results = db.Departments.Include("Projects").Include("Students").ToList();//.MakeViewModel();
            return results;
        }

        // GET: api/Departments/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Department))]
        public IHttpActionResult GetDepartment(int id)
        {
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpGet]
        [Route("byuniversity/{universityId:int}")]
        public IEnumerable<Department> GetDepartmentsByUniversity(int unversityID)
        {
            return db.Universities.Find(unversityID).Departments.ToList();
        }


        //// PUT: api/Departments/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutDepartment(int id, Department department)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != department.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(department).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DepartmentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Departments
        //[ResponseType(typeof(Department))]
        //public IHttpActionResult PostDepartment(Department department)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Departments.Add(department);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = department.Id }, department);
        //}

        //// DELETE: api/Departments/5
        //[ResponseType(typeof(Department))]
        //public IHttpActionResult DeleteDepartment(int id)
        //{
        //    Department department = db.Departments.Find(id);
        //    if (department == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Departments.Remove(department);
        //    db.SaveChanges();

        //    return Ok(department);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartmentExists(int id)
        {
            return db.Departments.Count(e => e.Id == id) > 0;
        }
    }

    public static class DepartmentEnumerableExtensions
    {
        //public static IEnumerable<object> MakeViewModel(this IEnumerable<Department> departments) {
        //    return departments.Select(d => new {
        //        d.Id,
        //        d.Name,
        //        Directions = d.Directions.Select(dir => new {
        //            dir.Id,
        //            dir.Name,
        //            dir.ShortDescription,
        //            dir.Description
        //        }),
        //        Projects = d.Projects.Select(p => new {
        //            p.Id,
        //            p.Category,
        //            p.Comment,
        //            p.Company,
        //            p.Description,
        //            p.StartDate,
        //            p.EndDate,
        //            p.Name,
        //            p.Tasks
        //        }),
        //        Statistics = d.Statitics,
        //        Students = d.Students.Select(s => new { s.Id, s.FirstName, s.LastName, s.PatronimicName}),
        //    }
        //    );
        //}
    }
}