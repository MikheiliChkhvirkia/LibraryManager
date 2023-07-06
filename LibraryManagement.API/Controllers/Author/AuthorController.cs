using LibraryManagement.API.Settings.BaseController;
using MediatR;

namespace LibraryManagement.API.Controllers.Author
{
    public class AuthorController : ApiControllerBase
    {
        public AuthorController(IMediator mediator)
        : base(mediator) { }

    }
}
