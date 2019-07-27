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

// namespace EdVision.WebApi.Controllers
// {
//     [RoutePrefix("api/jobstatistics")]
//     public class JobStatisticsController : ApiController
//     {
       
//         private MentoringContext db = new MentoringContext();

//         // GET: api/JobStatistics
//         [HttpGet]
//         [Route("")]
//         public IEnumerable<JobStatistics> GetJobStatistics()
//         {
//             return db.JobStatistics.ToList();
//         }

//         // GET: api/JobStatistics/5
//         [HttpGet]
//         [Route("{id:int}")]
//         [ResponseType(typeof(JobStatistics))]
//         public IHttpActionResult GetJobStatistics(int id)
//         {
//             JobStatistics JobStatistics = db.JobStatistics.Find(id);
//             if (JobStatistics == null)
//             {
//                 return NotFound();
//             }

//             return Ok(JobStatistics);
//         }

//         //// PUT: api/JobStatistics/5
//         //[ResponseType(typeof(void))]
//         //public IHttpActionResult PutJobStatistics(int id, JobStatistics JobStatistics)
//         //{
//         //    if (!ModelState.IsValid)
//         //    {
//         //        return BadRequest(ModelState);
//         //    }

//         //    if (id != JobStatistics.Id)
//         //    {
//         //        return BadRequest();
//         //    }

//         //    db.Entry(JobStatistics).State = EntityState.Modified;

//         //    try
//         //    {
//         //        db.SaveChanges();
//         //    }
//         //    catch (DbUpdateConcurrencyException)
//         //    {
//         //        if (!JobStatisticsExists(id))
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

//         //// POST: api/JobStatistics
//         //[ResponseType(typeof(JobStatistics))]
//         //public IHttpActionResult PostJobStatistics(JobStatistics JobStatistics)
//         //{
//         //    if (!ModelState.IsValid)
//         //    {
//         //        return BadRequest(ModelState);
//         //    }

//         //    db.JobStatistics.Add(JobStatistics);
//         //    db.SaveChanges();

//         //    return CreatedAtRoute("DefaultApi", new { id = JobStatistics.Id }, JobStatistics);
//         //}

//         //// DELETE: api/JobStatistics/5
//         //[ResponseType(typeof(JobStatistics))]
//         //public IHttpActionResult DeleteJobStatistics(int id)
//         //{
//         //    JobStatistics JobStatistics = db.JobStatistics.Find(id);
//         //    if (JobStatistics == null)
//         //    {
//         //        return NotFound();
//         //    }

//         //    db.JobStatistics.Remove(JobStatistics);
//         //    db.SaveChanges();

//         //    return Ok(JobStatistics);
//         //}

//         protected override void Dispose(bool disposing)
//         {
//             if (disposing)
//             {
//                 db.Dispose();
//             }
//             base.Dispose(disposing);
//         }

//         private bool JobStatisticsExists(int id)
//         {
//             return db.JobStatistics.Count(e => e.Id == id) > 0;
//         }
//     }
// }