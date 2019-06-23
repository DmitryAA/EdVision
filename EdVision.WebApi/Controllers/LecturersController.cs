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
    [RoutePrefix("api/lecturers")]
    public class LecturersController : ApiController
    {
        private MentoringContext db = new MentoringContext();

        // GET: api/Lecturers
        [HttpGet]
        [Route("")]
        public IEnumerable<Lecturer> GetLecturers()
        {
            return db.Lecturer.ToList();
        }

        // GET: api/Lecturers/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Lecturer))]
        public IHttpActionResult GetLecturer(int id)
        {
            Lecturer lecturer = db.Lecturer.Find(id);
            if (lecturer == null)
            {
                return NotFound();
            }

            return Ok(lecturer);
        }

        [HttpGet]
        [Route("byuniversity/{universityIid:int}")]
        public IEnumerable<Lecturer> GetLecturerByUniversity(int universityID)
        {
            var university = db.Universities.Find(universityID);
            var projects = university.Departments.SelectMany(x=>x.Directions.SelectMany(xx=>xx.Projects)).ToList(); 
            var tasks =  projects.SelectMany(x => x.Tasks);
            return tasks.Select(x => x.LecturerGrade.GradingPerson).Cast<Lecturer>().ToList();
        }

        [HttpGet]
        [Route("bydepartment/{departmentID:int}")]
        public IEnumerable<Lecturer> GetLecturerByDepartments(int departmentID)
        {
            var dep = db.Lecturer.Find(departmentID);
            return db.Lecturer.Where(d => d.Id == departmentID).ToList();
        }


        [HttpGet]
        [Route("byproject/{projectID:int}")]
        public IEnumerable<Lecturer> GetLecturerByProject(int projectID)
        {
            var project = db.Projects.Find(projectID);
            return project.Tasks.Select(x => (Lecturer)x.LecturerGrade.GradingPerson).Cast<Lecturer>().ToList();
        }


        //// PUT: api/Lecturers/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutLecturer(int id, Lecturer lecturer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != lecturer.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(lecturer).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!LecturerExists(id))
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

        //// POST: api/Lecturers
        //[ResponseType(typeof(Lecturer))]
        //public IHttpActionResult PostLecturer(Lecturer lecturer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Lecturer.Add(lecturer);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (LecturerExists(lecturer.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = lecturer.Id }, lecturer);
        //}

        //// DELETE: api/Lecturers/5
        //[ResponseType(typeof(Lecturer))]
        //public IHttpActionResult DeleteLecturer(int id)
        //{
        //    Lecturer lecturer = db.Lecturer.Find(id);
        //    if (lecturer == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Lecturer.Remove(lecturer);
        //    db.SaveChanges();

        //    return Ok(lecturer);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LecturerExists(int id)
        {
            return db.Lecturer.Count(e => e.Id == id) > 0;
        }
    }
}