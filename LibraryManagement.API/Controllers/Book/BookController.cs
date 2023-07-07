using LibraryManagement.API.Settings.BaseController;
using LibraryManagement.Applicaiton.Common;
using LibraryManagement.Applicaiton.Handlers.Books.Commands.AddBookAndAuthors;
using LibraryManagement.Applicaiton.Handlers.Books.Commands.BindAuthorToBook;
using LibraryManagement.Applicaiton.Handlers.Books.Commands.BorrowBook;
using LibraryManagement.Applicaiton.Handlers.Books.Commands.Delete;
using LibraryManagement.Applicaiton.Handlers.Books.Commands.RateBook;
using LibraryManagement.Applicaiton.Handlers.Books.Commands.Update;
using LibraryManagement.Applicaiton.Handlers.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class BookController : ApiControllerBase
    {
        public BookController(IMediator mediator)
        : base(mediator) { }

        [HttpGet]
        public Task<PagedData<GetBooksQueryModel>> Get(int id)
            => mediator.Send(new GetBooksQuery { Id = id });

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

        [HttpPatch("{Id}/Borrow-And-Return")]
        public Task BorrowBook(int Id, bool IsBorrowing = false)
            => mediator.Send(new BorrowBookCommand
            {
                Id = Id,
                IsBorrowing = IsBorrowing
            });

        [HttpPatch("{Id}/rate-book")]
        public Task RateBook(int Id, int rating)
            => mediator.Send(new RateBookCommand(Id, rating));

        [HttpPatch("{Id}/bind-author")]
        public Task BindAuthorToBook(int Id, int AuthorId)
            => mediator.Send(new BindAuthorToBookCommand
            {
                BookId = Id,
                AuthorId = AuthorId
            });

        [HttpDelete("{Id}/Delete")]
        public Task DeleteBook(int Id)
            => mediator.Send(new DeleteBookCommand { Id = Id });
    }
}