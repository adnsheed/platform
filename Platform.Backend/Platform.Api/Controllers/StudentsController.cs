using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Common;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Student;

namespace Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentsService studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto newStudent)
        {
            return Ok(await studentsService.Create(newStudent));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await studentsService.Delete(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]  RequestParameters studentParameters)
        {
            return Ok(await studentsService.GetAll(studentParameters));
        }

        [Authorize(Roles = "Student")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await studentsService.GetById(id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudentDto updatedStudent)
        {
            return Ok(await studentsService.Update(id, updatedStudent));
        }
    }
}
