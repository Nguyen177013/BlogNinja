using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebBlog.Models;
using WebBlog.Services;

namespace WebBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;

        public HomeController(IBlogService blogService)
        {
            this._blogService = blogService;
        }

        public IActionResult Index()
        {
            IEnumerable<Blog> blogs =  this._blogService.GetAll();
            return View(blogs);
        }

        public IActionResult About()
        {
            return View();
        }

    }
}