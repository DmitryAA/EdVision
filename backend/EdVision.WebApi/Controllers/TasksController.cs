using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EdVision.Models;
using EdVision.DataLayer;

 namespace EdVision.WebApi.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : Controller {
        private readonly UniversityStatisticsContext db;

        public TasksController(UniversityStatisticsContext db) {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentTask>> GetTasks([FromQuery(Name = "project_id")] int? projectId) {
            IQueryable<StudentTask> tasks = db.Tasks;
            if (projectId != null) {
                tasks = tasks.Where(t => t.ProjectId == projectId);
            }
            return Ok(tasks.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<StudentTask> GetTask(int id) {
            StudentTask task = db.Tasks.Find(id);
            if (task == null) {
                NotFound();
            }
            return Ok(task);
        }
    }
}