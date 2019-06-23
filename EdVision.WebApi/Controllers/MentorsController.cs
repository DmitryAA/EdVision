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
    public class MentorsController : ApiController
    {
        private MentoringContext db = new MentoringContext();

        // GET: api/Mentors
        public IEnumerable<Mentor> GetPeople()
        {
            return db.Mentors.ToList();
        }

        // GET: api/Mentors/5
        [ResponseType(typeof(Mentor))]
        public IHttpActionResult GetMentor(int id)
        {
            Mentor mentor = db.Mentors.Find(id);
            if (mentor == null)
            {
                return NotFound();
            }

            return Ok(mentor);
        }

        // GET: api/Students
        public IEnumerable<Mentor> GetLecturerByUniversity(int universityID)
        {
            var university = db.Universities.Find(universityID);
            var projects = university.Departments.SelectMany(x => x.Directions).SelectMany(x => x.Projects);
            var tasks = projects.SelectMany(x => x.Tasks);
            return tasks.Select(x => x.MentorGrade.GradingPerson).Cast<Mentor>().ToList();
        }

        // GET: api/Students
        public IEnumerable<Mentor> GetMentorsByCompany(int companyID)
        {
            var mentor = db.Companies.Find(companyID).Mentors.ToList();
            return mentor;
        }

        // GET: api/Students
        public IEnumerable<Mentor> GetMentorByProjectID(int projectID)
        {
            var project = db.Projects.Find(projectID);
            return project.Tasks.Select(x=>x.MentorGrade.GradingPerson).Cast<Mentor>();
        }


        



        // PUT: api/Mentors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMentor(int id, Mentor mentor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mentor.Id)
            {
                return BadRequest();
            }

            db.Entry(mentor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MentorExists(id))
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

        // POST: api/Mentors
        [ResponseType(typeof(Mentor))]
        public IHttpActionResult PostMentor(Mentor mentor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mentors.Add(mentor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MentorExists(mentor.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mentor.Id }, mentor);
        }

        // DELETE: api/Mentors/5
        [ResponseType(typeof(Mentor))]
        public IHttpActionResult DeleteMentor(int id)
        {
            Mentor mentor = db.Mentors.Find(id);
            if (mentor == null)
            {
                return NotFound();
            }

            db.Mentors.Remove(mentor);
            db.SaveChanges();

            return Ok(mentor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MentorExists(int id)
        {
            return db.Mentors.Count(e => e.Id == id) > 0;
        }
    }
}