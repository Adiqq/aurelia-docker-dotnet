using Microsoft.AspNetCore.Mvc;
using Application.Commands;
using WebAPI.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly IPageService _pageService;
        public CommentsController(IPageService pageService) {
            _pageService = pageService;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody]CreateCommentCommand command)
        {
            _pageService.AddComment(command);
        }
    }
}
