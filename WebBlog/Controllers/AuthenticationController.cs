using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebBlog.Models;
using WebBlog.Services;
using WebBlog.Utils;

namespace WebBlog.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly JwtUtils jwtUtils = new JwtUtils();
        public AuthenticationController(IAuthorService authorService)
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
            string token = jwtUtils.GenerateJwtToken(author);
            var cookieOptions = new CookieOptions();
            cookieOptions.Path = "/";
            cookieOptions.Secure = true;
            cookieOptions.HttpOnly = true;
            Response.Cookies.Append("jwt", token,cookieOptions);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Author author)
        {
            Author filterAuthor = this._authorService.FindAuthor(author);
            if(filterAuthor == null)
            {
                return NotFound();
            }
            string token = jwtUtils.GenerateJwtToken(filterAuthor);
            var cookieOptions = new CookieOptions();
            cookieOptions.Path = "/";
            cookieOptions.Secure = true;
            cookieOptions.HttpOnly = true;
            Response.Cookies.Append("jwt", token, cookieOptions);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            //HttpContext.Items.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
