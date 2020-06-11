﻿using Lab456.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab456.Controllers
{
    [Authorize]
    public class AttendencesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AttendencesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend([FromBody] int courseId)
        {
            var attendence = new Attendence
            {
                CourseId = courseId,
                AttendeeId = int.Parse(User.Identity.GetUserId())
            };

            _dbContext.Attendences.Add(attendence);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
