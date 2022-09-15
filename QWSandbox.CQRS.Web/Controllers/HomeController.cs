using Microsoft.AspNetCore.Mvc;
using QWSandbox.CQRS.Web.Models;
using System.Diagnostics;
using MediatR;
using QWSandbox.CQRS.Web.Models.Home;

namespace QWSandbox.CQRS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            _logger.LogError("Test error");
            return View();
        }

        [HttpPost("")]
        public IActionResult Index(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}