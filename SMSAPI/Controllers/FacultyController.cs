using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.DbModels;
using Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.RepositoryBase;
using Repositories.Interfaces;
using Services.BusinessLogic;

namespace SMSAPI.Controllers
{
    // controller for Faculty

    [Route("api/Faculty")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly FacultyService _facultyService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faculty>>> GetFaculty()
        {
            var faculties = await _facultyService.GetAllFacultiesAsync();
            return Ok(faculties); // Ok is the 200 OK status code
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Faculty>> GetFaculty(int id)
        {
            var faculty = await _facultyService.GetFacultyByIdAsync(id);
            if (faculty == null)
            {
                return NotFound(); // 404 response
            }
            return Ok(faculty); // 200 OK status
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFaculty(int id, Faculty updatedFaculty)
        {
            if (id != updatedFaculty.Id)
            {
                return BadRequest("Faculty ID mismatch");
            }

            var result = await _facultyService.UpdateFacultyAsync(id, updatedFaculty);

            if (result)
            {
                return NoContent(); // Success: No content to return
            }
            else
            {
                return NotFound(); // Faculty not found or update failed
            }
        }

        [HttpPost]
        public async Task<ActionResult<Faculty>> AddFaculty(Faculty faculty)
        {
            if (faculty == null)
            {
                return BadRequest("Faculty object is null.");
            }

            // Add the new faculty to the repository
            await _facultyService.AddFacultyAsync(faculty);

            // Return a response with the newly created faculty and the status code 201 (Created)
            return CreatedAtAction(nameof(GetFaculty), new { id = faculty.Id }, faculty);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaculty(int id)
        {
            var faculty = await _facultyService.GetFacultyByIdAsync(id);
            if (faculty == null)
            {
                return NotFound($"Faculty with ID {id} not found.");
            }

            await _facultyService.DeleteFacultyAsync(id);
            return NoContent(); // Status 204 (No Content) to indicate successful deletion
        }


    }
}
