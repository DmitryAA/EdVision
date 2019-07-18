// using System;
// using System.Collections.Generic;
// using System.Data;
// using System.Data.Entity;
// using System.Data.Entity.Infrastructure;
// using System.Linq;
// using System.Net;
// using System.Net.Http;
// using System.Web.Http;
// using System.Web.Http.Description;
// using EdVision.WebApi.Model;
// using EdVision.WebApi.Models;

// namespace EdVision.WebApi.Controllers
// {
//     [RoutePrefix("api/students")]
//     public class StudentsController : ApiController
//     {
//         private MentoringContext db = new MentoringContext();

//         // GET: api/Students/5
//         [HttpGet]
//         [Route("")]
//         public IEnumerable<Student> GetStudents() {
//             return db.Students.ToList();
//         }

//         // GET: api/Students/5
//         [HttpGet]
//         [Route("{id:int}")]
//         public Student GetStudent(int id) {
//             Student student = db.Students.Include(s => s.ProjectResults).Include(s => s.Tasks).FirstOrDefault(s => s.Id == id);
//             return student;
//         }

//         // GET: api/Students/StudentsByDepartment/5
//         [HttpGet]
//         [Route("byuniversity/{universityID:int}")]
//         public IEnumerable<Student> GetStudentsByUniversity(int universityID)
//         {
//             var university = db.Universities.Find(universityID);
//             var dep = university.Departments; 
//             return dep.SelectMany(d=>d.Directions.SelectMany(x=>x.Students)).ToList();
//         }

//         // GET: api/Students
//         [HttpGet]
//         [Route("bydepartments/{departmentID:int}")]
//         public IEnumerable<Student> GetStudentsByDepartments(int departmentID)
//         {
//             var dep = db.Students.Find(departmentID);
//             return db.Students.Where(d=>d.Id == departmentID).ToList();
//         }


//         // GET: api/Students/StudentsByProject/{id}
//         [HttpGet]
//         [Route("byproject/{projectID:int}")]
//         public IEnumerable<Student> GetStudentsByProject(int projectID)
//         {
//             var project = db.Projects.Find(projectID);
//             if (project == null) return new List<Student>();
//             var tasks = project.Tasks;
//             return db.Students.Where(s => s.Tasks.Intersect(project.Tasks).Count() > 0).ToList();
//         }


//         [HttpGet]
//         [Route("{studentID}/portfolio")]
//         public Portfolio GetPortfolio(int studentID) {
//             var student = db.Students.Find(studentID);
//             if (student == null) return null;
//             var tasks = student.Tasks.ToList();
//             var projects = db.Projects.Where(p => p.Tasks.Intersect(tasks).Count() > 0);
//             double mentorRaiting = tasks.Average(x => (double)x.MentorGrade.Value);
//             double lectureGrade = tasks.Average(x => (double)x.LecturerGrade.Value);
//             var direction = db.EducationDirections.ToList().FirstOrDefault(d => d.Students.Contains(student));
//             var department = db.Departments.ToList().FirstOrDefault(d => d.Directions.Contains(direction));//.SelectMany(x=>x.Students.Contains(student));
//             var university = db.Universities.ToList().FirstOrDefault(x => x.Departments.Contains(department));

//             return new Portfolio {
//                 LecturerRating = lectureGrade,
//                 MenthorRating = mentorRaiting,
//                 PersonDepartment = department,
//                 PersonInfo = student,
//                 PersonUniversity = university,
//                 ProjectTasks = tasks
//             };
//         }


       

//         // PUT: api/Students/5
//         //[ResponseType(typeof(void))]
//         //public IHttpActionResult PutStudent(int id, Student student)
//         //{
//         //    if (!ModelState.IsValid)
//         //    {
//         //        return BadRequest(ModelState);
//         //    }

//         //    if (id != student.Id)
//         //    {
//         //        return BadRequest();
//         //    }

//         //    db.Entry(student).State = EntityState.Modified;

//         //    try
//         //    {
//         //        db.SaveChanges();
//         //    }
//         //    catch (DbUpdateConcurrencyException)
//         //    {
//         //        if (!StudentExists(id))
//         //        {
//         //            return NotFound();
//         //        }
//         //        else
//         //        {
//         //            throw;
//         //        }
//         //    }

//         //    return StatusCode(HttpStatusCode.NoContent);
//         //}

//         //// POST: api/Students
//         //[ResponseType(typeof(Student))]
//         //public IHttpActionResult PostStudent(Student student)
//         //{
//         //    if (!ModelState.IsValid)
//         //    {
//         //        return BadRequest(ModelState);
//         //    }

//         //    db.Students.Add(student);

//         //    try
//         //    {
//         //        db.SaveChanges();
//         //    }
//         //    catch (DbUpdateException)
//         //    {
//         //        if (StudentExists(student.Id))
//         //        {
//         //            return Conflict();
//         //        }
//         //        else
//         //        {
//         //            throw;
//         //        }
//         //    }

//         //    return CreatedAtRoute("DefaultApi", new { id = student.Id }, student);
//         //}

//         //// DELETE: api/Students/5
//         //[ResponseType(typeof(Student))]
//         //public IHttpActionResult DeleteStudent(int id)
//         //{
//         //    Student student = db.Students.Find(id);
//         //    if (student == null)
//         //    {
//         //        return NotFound();
//         //    }

//         //    db.Students.Remove(student);
//         //    db.SaveChanges();

//         //    return Ok(student);
//         //}

//         protected override void Dispose(bool disposing)
//         {
//             if (disposing)
//             {
//                 db.Dispose();
//             }
//             base.Dispose(disposing);
//         }

//         private bool StudentExists(int id)
//         {
//             return db.Students.Count(e => e.Id == id) > 0;
//         }
//     }
// }