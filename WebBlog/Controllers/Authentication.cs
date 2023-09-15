using Microsoft.AspNetCore.Mvc;
using WebBlog.Models;
using WebBlog.Services;

namespace WebBlog.Controllers
{
    public class Authentication : Controller
    {
        private readonly IAuthorService _authorService;

        public Authentication(IAuthorService authorService)
        {
            this._authorService = authorService;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Author author)
        {
            author.CreatedDate = DateTime.Now;
            this._authorService.Add(author);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
    }
}
