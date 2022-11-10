using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Common;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Selection;

namespace Platform.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionsController : Controller
    {
        private readonly ISelectionsService selectionsService;

        public SelectionsController(ISelectionsService selectionsService)
        {
            this.selectionsService = selectionsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestParameters selectionParameters)
        {
            return Ok(await selectionsService.GetAll(selectionParameters));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await selectionsService.GetById(id));
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateSelectionDto newSelection)
        {
            return Ok(await selectionsService.Create(newSelection));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateSelectionDto updatedSelection)
        {
            return Ok(await selectionsService.Update(id, updatedSelection));
        }

        [HttpPut("AddStudent")]
        public async Task<IActionResult> AddStudent(Guid selectionId, int studentId, Guid programId)
        {
            return Ok(await selectionsService.AddStudent(selectionId, studentId,programId));
        }

        [HttpPut("RemoveStudent")]
        public async Task<IActionResult> RemoveStudent(Guid selectionId, int studentId)
        {
            return Ok(await selectionsService.RemoveStudent(selectionId, studentId));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await selectionsService.Delete(id));
        }


    }
}
