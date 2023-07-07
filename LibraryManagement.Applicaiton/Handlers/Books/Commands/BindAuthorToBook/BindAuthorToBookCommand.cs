using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Books.Commands.BindAuthorToBook
{
    public class BindAuthorToBookCommand : IRequest
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    }
}
