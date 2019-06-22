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
    public class CourseResultsController : ApiController
    {
        private MentoringContext db = new MentoringContext();

        // GET: api/CourseResults
        public IEnumerable<CourseResult> GetCourseResults()
        {
            return db.CourseResults.ToList();
        }

        // GET: api/CourseResults/5
        [ResponseType(typeof(CourseResult))]
        public IHttpActionResult GetCourseResult(int id)
        {
            CourseResult courseResult = db.CourseResults.Find(id);
            if (courseResult == null)
            {
                return NotFound();
            }

            return Ok(courseResult);
        }

        // PUT: api/CourseResults/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourseResult(int id, CourseResult courseResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courseResult.Id)
            {
                return BadRequest();
            }

            db.Entry(courseResult).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseResultExists(id))
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

        // POST: api/CourseResults
        [ResponseType(typeof(CourseResult))]
        public IHttpActionResult PostCourseResult(CourseResult courseResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CourseResults.Add(courseResult);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = courseResult.Id }, courseResult);
        }

        // DELETE: api/CourseResults/5
        [ResponseType(typeof(CourseResult))]
        public IHttpActionResult DeleteCourseResult(int id)
        {
            CourseResult courseResult = db.CourseResults.Find(id);
            if (courseResult == null)
            {
                return NotFound();
            }

            db.CourseResults.Remove(courseResult);
            db.SaveChanges();

            return Ok(courseResult);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseResultExists(int id)
        {
            return db.CourseResults.Count(e => e.Id == id) > 0;
        }
    }
}