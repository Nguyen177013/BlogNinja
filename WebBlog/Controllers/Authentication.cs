using Microsoft.AspNetCore.Mvc;
using WebBlog.Models;
using WebBlog.Services;

namespace WebBlog.Controllers
{
    public class Authentication : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
    }
}
