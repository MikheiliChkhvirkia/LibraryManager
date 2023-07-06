using LibraryManagement.API.Settings.BaseController;
using LibraryManagement.Applicaiton.Handlers.Books.Commands.AddBookAndAuthors;
using LibraryManagement.Applicaiton.Handlers.Books.Commands.Delete;
using LibraryManagement.Applicaiton.Handlers.Books.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class BookController : ApiControllerBase
    {
        public BookController(IMediator mediator)
        : base(mediator) { }

        [HttpPost("add")]
        public Task AddBookAndAuthors([FromBody] AddBookAndAuthorsCommand request)
            => mediator.Send(request);

        [HttpPatch("update")]
        public Task UpdateBook([FromBody] UpdateBookCommand request)
            => mediator.Send(request);

        [HttpDelete("delete")]
        public Task DeleteBook([FromBody] DeleteBookCommand request)
            => mediator.Send(request);
    }
}