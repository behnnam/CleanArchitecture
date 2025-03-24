using BlogApi.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Presentation.Controllers
{
    [Authorize]
    public class PostsController : BaseApiController
    {
        private readonly IGetPostService _context;

        public PostsController(IGetPostService context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> GetAllPost()
        {
            var res = await _context.GetAllPostAsync();

            return Ok(res);


        }
    }
}
