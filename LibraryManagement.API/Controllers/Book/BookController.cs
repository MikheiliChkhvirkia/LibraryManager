using LibraryManagement.API.Settings.BaseController;
using LibraryManagement.Applicaiton.Handlers.Books.Commands.AddBookAndAuthors;
using LibraryManagement.Applicaiton.Handlers.Books.Commands.BorrowBook;
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

        [HttpPost]
        public Task AddBookAndAuthors([FromBody] AddBookAndAuthorsCommand request)
            => mediator.Send(request);

        [HttpPatch("{Id}/Update")]
        public Task UpdateBook(int Id, [FromBody] UpdateBookCommandModel request)
            => mediator.Send(new UpdateBookCommand
            {
                Id = Id,
                Model = request
            });

        [HttpDelete]
        public Task DeleteBook([FromBody] DeleteBookCommand request)
            => mediator.Send(request);

        [HttpPatch("{Id}/Borrow-Return")]
        public Task BorrowBook(int id, [FromQuery] bool isReturning = false)
            => mediator.Send(new BorrowBookCommand
            {
                Id = id,
                IsReturning = isReturning
            });
    }
}