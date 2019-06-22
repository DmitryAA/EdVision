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
    public class UniversitiesController : ApiController
    {
        private MentoringContext db = new MentoringContext();

        // GET: api/Universities
        public IEnumerable<University> GetUniversities()
        {
            return db.Universities.ToList();
        }

        // GET: api/Universities/5
        [ResponseType(typeof(University))]
        public IHttpActionResult GetUniversity(int id)
        {
            University university = db.Universities.Find(id);
            if (university == null)
            {
                return NotFound();
            }

            return Ok(university);
        }

        // PUT: api/Universities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUniversity(int id, University university)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != university.Id)
            {
                return BadRequest();
            }

            db.Entry(university).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityExists(id))
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

        // POST: api/Universities
        [ResponseType(typeof(University))]
        public IHttpActionResult PostUniversity(University university)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Universities.Add(university);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = university.Id }, university);
        }

        // DELETE: api/Universities/5
        [ResponseType(typeof(University))]
        public IHttpActionResult DeleteUniversity(int id)
        {
            University university = db.Universities.Find(id);
            if (university == null)
            {
                return NotFound();
            }

            db.Universities.Remove(university);
            db.SaveChanges();

            return Ok(university);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UniversityExists(int id)
        {
            return db.Universities.Count(e => e.Id == id) > 0;
        }
    }
}