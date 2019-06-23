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
    [RoutePrefix("api/jobstatistics")]
    public class JobStatiticsController : ApiController
    {
       
        private MentoringContext db = new MentoringContext();

        // GET: api/JobStatitics
        [HttpGet]
        [Route("")]
        public IEnumerable<JobStatitics> GetJobStatitics()
        {
            return db.JobStatitics.ToList();
        }

        // GET: api/JobStatitics/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(JobStatitics))]
        public IHttpActionResult GetJobStatitics(int id)
        {
            JobStatitics jobStatitics = db.JobStatitics.Find(id);
            if (jobStatitics == null)
            {
                return NotFound();
            }

            return Ok(jobStatitics);
        }

        //// PUT: api/JobStatitics/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutJobStatitics(int id, JobStatitics jobStatitics)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != jobStatitics.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(jobStatitics).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!JobStatiticsExists(id))
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

        //// POST: api/JobStatitics
        //[ResponseType(typeof(JobStatitics))]
        //public IHttpActionResult PostJobStatitics(JobStatitics jobStatitics)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.JobStatitics.Add(jobStatitics);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = jobStatitics.Id }, jobStatitics);
        //}

        //// DELETE: api/JobStatitics/5
        //[ResponseType(typeof(JobStatitics))]
        //public IHttpActionResult DeleteJobStatitics(int id)
        //{
        //    JobStatitics jobStatitics = db.JobStatitics.Find(id);
        //    if (jobStatitics == null)
        //    {
        //        return NotFound();
        //    }

        //    db.JobStatitics.Remove(jobStatitics);
        //    db.SaveChanges();

        //    return Ok(jobStatitics);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobStatiticsExists(int id)
        {
            return db.JobStatitics.Count(e => e.Id == id) > 0;
        }
    }
}