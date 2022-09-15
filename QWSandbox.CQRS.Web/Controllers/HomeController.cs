using Microsoft.AspNetCore.Mvc;
using QWSandbox.CQRS.Web.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AutoMapper;
using MediatR;
using QWSandbox.CQRS.Domain.Models.User;
using QWSandbox.CQRS.Web.Infrastructure.Mediator.User;
using QWSandbox.CQRS.Web.Models.Home;

namespace QWSandbox.CQRS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            _logger.LogError("Test error");

            List<UserModel> userModels = await _mediator.Send(new GetUsersRequest());

            var userViewModels = _mapper.Map<List<UserViewModel>>(userModels);

            return View(new HomeViewModel
            {
                Users = userViewModels
            });
        }

        [HttpPost("")]
        public IActionResult Index(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }



            return RedirectToAction("Index");
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