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
    // Controller for Faculties

    [Route("api/faculties")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faculty>>> GetFaculties()
        {
            var faculties = await _facultyService.GetAllAsync();
            return Ok(faculties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Faculty>> GetFaculty(int id)
        {
            var faculty = await _facultyService.GetByIdAsync(id);

            if (faculty == null)
            {
                return NotFound();
            }

            return faculty;
        }

        [HttpPost]
        public async Task<ActionResult<Faculty>> PostFaculty(Faculty faculty)
        {
            await _facultyService.AddAsync(faculty);
            return CreatedAtAction("GetFaculty", new { id = faculty.Id }, faculty);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaculty(int id, Faculty faculty)
        {
            var success = await _facultyService.UpdateAsync(id, faculty);
            if (!success)
            {
                return NotFound(); // code 404 if not found
            }

            return NoContent(); // code 204 if successful
        }





        [HttpDelete("{id}")]
        public async Task<ActionResult<Faculty>> DeleteFaculty(int id)
        {
            var faculty = await _facultyService.GetByIdAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }

            await _facultyService.DeleteAsync(id);
            return Ok(faculty);
        }
    }
}