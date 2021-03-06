﻿using System;
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
    [RoutePrefix("api/universities")]
    public class UniversitiesController : ApiController
    {
        private MentoringContext db = new MentoringContext();

        [HttpGet]
        [Route("")]
        public IEnumerable<University> GetUniversities()
        {
            //db.Universities.First().Address.City
            return db.Universities.Include("Departments").ToList();
        }

        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(University))]
        public IHttpActionResult GetUniversity(int id)
        {
            University university = db.Universities.Include("Departments").FirstOrDefault(u => u.Id == id);
            if (university == null)
            {
                return NotFound();
            }

            return Ok(university);
        }

        [HttpGet]
        [Route("byregion/{regionId:int}")]
        public IEnumerable<University> GetUniversitiesByRegion(int regionId) {
            var universities = db.Universities.Where(u => u.Address.City.Region == db.Regions.Find(regionId));
            return universities.ToList();
        }


        


        //// PUT: api/Universities/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUniversity(int id, University university)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != university.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(university).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UniversityExists(id))
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

        //// POST: api/Universities
        //[ResponseType(typeof(University))]
        //public IHttpActionResult PostUniversity(University university)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Universities.Add(university);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = university.Id }, university);
        //}

        //// DELETE: api/Universities/5
        //[ResponseType(typeof(University))]
        //public IHttpActionResult DeleteUniversity(int id)
        //{
        //    University university = db.Universities.Find(id);
        //    if (university == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Universities.Remove(university);
        //    db.SaveChanges();

        //    return Ok(university);
        //}

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