using MediatR;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.API.Settings.BaseController;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryManagement.Controllers
{
    public class HomeController : ApiControllerBase
    {
        public HomeController(IMediator mediator)
        : base(mediator) { }


        [HttpGet]
        [SwaggerOperation("Works?")]
        public string Get()
        {
            return "Works";
        }
    }
}