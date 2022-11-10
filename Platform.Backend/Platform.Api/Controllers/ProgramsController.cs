using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Core.Interfaces;
using Platform.Core.Requests.ItemProgram;

namespace Platform.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : Controller
    {
        private readonly IProgramsService programService;

        public ProgramsController(IProgramsService programService)
        {
            this.programService = programService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await programService.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await programService.GetById(id));
        }

        [HttpPost("Additem")]
        public async Task<IActionResult> AddItem(AddItemProgramDto addItemProgram)
        {
            return Ok(await programService.AddItem(addItemProgram));
        }

        [HttpDelete("RemoveItem")]
        public async Task<IActionResult> DeleteItem(Guid programId, int itemId)
        {
            return Ok(await programService.DeleteItem(programId, itemId));
        }

        [HttpPut("ChangeOrder")]
        public async Task<IActionResult> ChangeItemOrder(Guid programId, int itemId, int orderNumber)
        {
            return Ok(await programService.ChangeItemOrder(programId, itemId, orderNumber));
        }
    }
}
