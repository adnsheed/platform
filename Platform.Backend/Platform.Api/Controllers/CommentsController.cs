using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Comment;
using Platform.Services;

namespace Platform.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentDto newComment)
        {
            return Ok(await commentsService.Create(newComment));
        }

    }
}
