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
    public class LecturersController : ApiController
    {
        private MentoringContext db = new MentoringContext();

        // GET: api/Lecturers
        public IEnumerable<Lecturer> GetPeople()
        {
            return db.Lecturer.ToList();
        }

        // GET: api/Lecturers/5
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

        // PUT: api/Lecturers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLecturer(int id, Lecturer lecturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lecturer.Id)
            {
                return BadRequest();
            }

            db.Entry(lecturer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturerExists(id))
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

        // POST: api/Lecturers
        [ResponseType(typeof(Lecturer))]
        public IHttpActionResult PostLecturer(Lecturer lecturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lecturer.Add(lecturer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LecturerExists(lecturer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lecturer.Id }, lecturer);
        }

        // DELETE: api/Lecturers/5
        [ResponseType(typeof(Lecturer))]
        public IHttpActionResult DeleteLecturer(int id)
        {
            Lecturer lecturer = db.Lecturer.Find(id);
            if (lecturer == null)
            {
                return NotFound();
            }

            db.Lecturer.Remove(lecturer);
            db.SaveChanges();

            return Ok(lecturer);
        }

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