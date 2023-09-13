using Microsoft.AspNetCore.Mvc;
using WebBlog.Models;
using WebBlog.Services;

namespace WebBlog.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;

        private readonly IGenreService _genreService;
        public BlogsController(IBlogService blogService, IGenreService genreService)
        {
            this._blogService = blogService;
            this._genreService = genreService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            BlogCreateModel createBlogModel = new BlogCreateModel { Genres = this._genreService.GetAll() };
            return View(createBlogModel);

        }

        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            try
            {
                blog.Author_Id = 1;
                this._blogService.Add(blog);

            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index", "Home");
        }

    }
}
