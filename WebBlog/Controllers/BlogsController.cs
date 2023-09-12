using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBlog.Services;

namespace WebBlog.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IGenreService _blogService;

        public BlogsController(IGenreService blogService)
        {
            this._blogService = blogService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

    }
}
