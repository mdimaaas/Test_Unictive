using Microsoft.AspNetCore.Mvc;

namespace UnictiveTest.Controllers
{
    public class LoginController : Controller
    {
        private readonly JwtService _jwtService;

        public LoginController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Login";
            return View(ViewData);
        }

        [HttpPost]
        public IActionResult LoginProcess(string username, string password)
        {
            if (username == "user" && password == "12345")
            {
                var token = _jwtService.GenerateToken("1", username);
                HttpContext.Response.Cookies.Append("AuthToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict
                });
                return RedirectToAction("Index", "User");
            }

            ViewBag.Error = "Username atau password salah.";
            return View("Index");
        }
    }
}
