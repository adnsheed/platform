using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Core.Interfaces;

namespace Platform.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : Controller
    {
        private readonly IAdminService adminService;

        public AdminsController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet("report")]
        public async Task<ActionResult> Report()
        {
            return Ok(await adminService.Report());
        }
    }
}
