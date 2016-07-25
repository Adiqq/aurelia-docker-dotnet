using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Core;
using WebAPI.Services;
using Infrastructure.Data.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PagesController : Controller
    {
        private readonly IPageService _pageService;
        public PagesController(IPageService pageService) {
            _pageService = pageService;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public Page Get(string id) {
            return _pageService.GetPageByName(id);
        }
    }
}
