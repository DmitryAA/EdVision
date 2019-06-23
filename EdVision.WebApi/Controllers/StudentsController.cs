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
using EdVision.WebApi.Models;

namespace EdVision.WebApi.Controllers
{
    public class StudentsController : ApiController
    {
        private MentoringContext db = new MentoringContext();

        // GET: api/Students
        public IEnumerable<Student> Index()
        {
            return db.Students.ToList();
        }

        // GET: api/Students
        public IEnumerable<Student> GetStudentsByUniversity(int universityID)
        {
            var university = db.Universities.Find(universityID);
            var dep = university.Departments; 
            return dep.SelectMany(d=>d.Directions.SelectMany(x=>x.Students)).ToList();
        }

        public Portfolio GetPortfolio(int studentID)
        {
            var tasks = db.Projects.SelectMany(x => x.Tasks.Where(xx => xx.Performer.Id == studentID)).Include("LecturerGrade").Include("MentorGrade").ToList();
            var projects = db.Projects.Where(p => p.Tasks.Intersect(tasks).Count() > 0);            
            double mentorRaiting = tasks.Average(x => (double)x.MentorGrade.Value);
            double lectureGrade = tasks.Average(x => (double)x.LecturerGrade.Value);
            var student = db.Students.Find(studentID);
            var direction = db.EducationDirections.FirstOrDefault(d => d.Students.Contains(student));
            var department = db.Departments.FirstOrDefault(d => d.Directions.Contains(direction));//.SelectMany(x=>x.Students.Contains(student));
            var university = db.Universities.FirstOrDefault(x => x.Departments.Contains(department));

            return new Portfolio { LecturerRating = lectureGrade,
                MenthorRating = mentorRaiting,
                PersonDepartment = department,
                PersonInfo = student,
                PersonUniversity = university,
                ProjectTasks = tasks
            };
        }

        // GET: api/Students
        public IEnumerable<Student> GetStudentsByDepartments(int departmentID)
        {
            var dep = db.Students.Find(departmentID);
            return db.Students.Where(d=>d.Id == departmentID).ToList();
        }


        // GET: api/Students
        public IEnumerable<Student> GetStudentsByProject(int projectID)
        {
            var project = db.Projects.Find(projectID);
            return project.Tasks.Select(x=>x.Performer).ToList();
        }

        // GET: api/Students
        public IEnumerable<Student> GetPeople()
        {
            return db.Students.ToList();
        }

        // GET: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = db.Students.Include(s => s.ProjectResults).Include(s => s.Tasks).FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.Id)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.Id == id) > 0;
        }
    }
}