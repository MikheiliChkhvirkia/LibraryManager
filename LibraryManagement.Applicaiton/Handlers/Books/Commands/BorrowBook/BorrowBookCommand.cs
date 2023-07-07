using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Books.Commands.BorrowBook
{
    public class BorrowBookCommand : IRequest
    {
        public int Id { get; set; }
        public bool IsBorrowing { get; set; }
    }
}
