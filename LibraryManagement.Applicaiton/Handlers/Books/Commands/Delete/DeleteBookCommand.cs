using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Books.Commands.Delete
{
    public record DeleteBookCommand : IRequest
    {
        public int Id { get; set; }
    }
}
