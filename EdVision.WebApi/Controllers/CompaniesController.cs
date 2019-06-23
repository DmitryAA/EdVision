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
    [RoutePrefix("api/companies")]
    public class CompaniesController : ApiController
    {
        private MentoringContext db = new MentoringContext();

        // GET: api/Companies
        [HttpGet]
        [Route("")]
        public IEnumerable<Company> GetCompanies()
        {
            return db.Companies.ToList();
        }

        // GET: api/Companies/5
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(Company))]
        public IHttpActionResult GetCompany(int id)
        {
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        //// PUT: api/Companies/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutCompany(int id, Company company)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != company.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(company).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CompanyExists(id))
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

        //// POST: api/Companies
        //[ResponseType(typeof(Company))]
        //public IHttpActionResult PostCompany(Company company)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Companies.Add(company);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = company.Id }, company);
        //}

        //// DELETE: api/Companies/5
        //[ResponseType(typeof(Company))]
        //public IHttpActionResult DeleteCompany(int id)
        //{
        //    Company company = db.Companies.Find(id);
        //    if (company == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Companies.Remove(company);
        //    db.SaveChanges();

        //    return Ok(company);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyExists(int id)
        {
            return db.Companies.Count(e => e.Id == id) > 0;
        }
    }
}