﻿using Lab456.DTOs;
using Lab456.Models;
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
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendancesDto attendancesDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendancesDto.CourseId))
                return BadRequest("The Attendance is already exists!");

            var attendence = new Attendance
            {
                CourseId = attendancesDto.CourseId,
                AttendeeId = userId
            };

            _dbContext.Attendances.Add(attendence);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
