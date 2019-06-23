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
    [RoutePrefix("api/educationdirections")]
    public class EducationDirectionsController : ApiController
    {
        private MentoringContext db = new MentoringContext();

        // GET: api/EducationDirections
        [HttpGet]
        [Route("")]
        public IEnumerable<EducationDirection> GetEducationDirections()
        {
            return db.EducationDirections.ToList();
        }

        // GET: api/EducationDirections/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(EducationDirection))]
        public IHttpActionResult GetEducationDirection(int id)
        {
            EducationDirection educationDirection = db.EducationDirections.Find(id);
            if (educationDirection == null)
            {
                return NotFound();
            }

            return Ok(educationDirection);
        }

        //// PUT: api/EducationDirections/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutEducationDirection(int id, EducationDirection educationDirection)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != educationDirection.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(educationDirection).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EducationDirectionExists(id))
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

        //// POST: api/EducationDirections
        //[ResponseType(typeof(EducationDirection))]
        //public IHttpActionResult PostEducationDirection(EducationDirection educationDirection)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.EducationDirections.Add(educationDirection);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = educationDirection.Id }, educationDirection);
        //}

        //// DELETE: api/EducationDirections/5
        //[ResponseType(typeof(EducationDirection))]
        //public IHttpActionResult DeleteEducationDirection(int id)
        //{
        //    EducationDirection educationDirection = db.EducationDirections.Find(id);
        //    if (educationDirection == null)
        //    {
        //        return NotFound();
        //    }

        //    db.EducationDirections.Remove(educationDirection);
        //    db.SaveChanges();

        //    return Ok(educationDirection);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EducationDirectionExists(int id)
        {
            return db.EducationDirections.Count(e => e.Id == id) > 0;
        }
    }
}