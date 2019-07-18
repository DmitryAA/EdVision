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
//     [RoutePrefix("api/projects")]
//     public class ProjectsController : ApiController
//     {
//         private MentoringContext db = new MentoringContext();

//         [HttpGet]
//         [Route("")]
//         public IEnumerable<Project> GetProjects()
//         {
//             return db.Projects.ToList();
//         }

//         [HttpGet]
//         [Route("{id:int}")]
//         [ResponseType(typeof(Project))]
//         public IHttpActionResult GetProject(int id) {
//             Project project = db.Projects.Find(id);
//             if (project == null) {
//                 return NotFound();
//             }

//             return Ok(project);
//         }

//         [HttpGet]
//         [Route("byuniversity/{universityID:int}")]
//         public IEnumerable<Project> GetProjectsGetByUniversity(int universityID)
//         {
//             var university = db.Universities.Find(universityID);
//             var departments = university.Departments.SelectMany(d=> d.Directions).SelectMany(x => x.Projects).Distinct().ToList();
//             return departments;
//         }

//         [HttpGet]
//         [Route("bycompany/{companyID:int}")]
//         public IEnumerable<Project> GetProjectsGetByCompany(int companyID)
//         {
//             var result = db.Projects.Where(x => x.Company.Id == companyID);
//             return result;
//         }

//         [HttpGet]
//         [Route("bycompany/{companyID:int}/university/{universityID:int}")]
//         public IEnumerable<Project> GetProjectsGetByCompanyAndUniversity(int companyID, int universityID)
//         {
//             var university = db.Universities.Find(universityID);
//             var departments = university.Departments.SelectMany(d => d.Directions).SelectMany(x => x.Projects).Where(x=>x.Company.Id==companyID).Distinct().ToList();
//             return departments;
//         }

//         //// PUT: api/Projects/5
//         //[ResponseType(typeof(void))]
//         //public IHttpActionResult PutProject(int id, Project project)
//         //{
//         //    if (!ModelState.IsValid)
//         //    {
//         //        return BadRequest(ModelState);
//         //    }

//         //    if (id != project.Id)
//         //    {
//         //        return BadRequest();
//         //    }

//         //    db.Entry(project).State = EntityState.Modified;

//         //    try
//         //    {
//         //        db.SaveChanges();
//         //    }
//         //    catch (DbUpdateConcurrencyException)
//         //    {
//         //        if (!ProjectExists(id))
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

//         //// POST: api/Projects
//         //[ResponseType(typeof(Project))]
//         //public IHttpActionResult PostProject(Project project)
//         //{
//         //    if (!ModelState.IsValid)
//         //    {
//         //        return BadRequest(ModelState);
//         //    }

//         //    db.Projects.Add(project);
//         //    db.SaveChanges();

//         //    return CreatedAtRoute("DefaultApi", new { id = project.Id }, project);
//         //}

//         //// DELETE: api/Projects/5
//         //[ResponseType(typeof(Project))]
//         //public IHttpActionResult DeleteProject(int id)
//         //{
//         //    Project project = db.Projects.Find(id);
//         //    if (project == null)
//         //    {
//         //        return NotFound();
//         //    }

//         //    db.Projects.Remove(project);
//         //    db.SaveChanges();

//         //    return Ok(project);
//         //}

//         protected override void Dispose(bool disposing)
//         {
//             if (disposing)
//             {
//                 db.Dispose();
//             }
//             base.Dispose(disposing);
//         }

//         private bool ProjectExists(int id)
//         {
//             return db.Projects.Count(e => e.Id == id) > 0;
//         }
//     }
// }