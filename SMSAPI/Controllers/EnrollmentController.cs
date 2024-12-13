using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.DbModels;
using Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Services.BusinessLogic;
using Services.ServicesBase;
using Services.ServiceImplementation;

namespace SMSAPI.Controllers
{
    // Controller for Enrollments

    [Route("api/enrollment")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollments()
        {
            var enrollments = await _enrollmentService.GetAllAsync();
            return Ok(enrollments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> GetEnrollment(int id)
        {
            var enrollment = await _enrollmentService.GetByIdAsync(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return enrollment;
        }

        [HttpPost]
        public async Task<ActionResult<Enrollment>> PostCourse(Enrollment enrollment)
        {
            await _enrollmentService.AddAsync(enrollment);
            return CreatedAtAction("GetCourse", new { id = enrollment.Id }, enrollment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Enrollment enrollment)
        {
            var success = await _enrollmentService.UpdateAsync(id, enrollment);
            if (!success)
            {
                return NotFound(); // code 404 if not found
            }

            return NoContent(); // code 204 if successful
        }





        [HttpDelete("{id}")]
        public async Task<ActionResult<Enrollment>> DeleteEnrollment(int id)
        {
            var course = await _enrollmentService.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            await _enrollmentService.DeleteAsync(id);
            return Ok(course);
        }
    }
}