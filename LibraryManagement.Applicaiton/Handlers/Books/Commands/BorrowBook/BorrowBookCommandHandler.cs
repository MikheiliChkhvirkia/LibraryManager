using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Books.Commands.BorrowBook
{
    public class BorrowBookCommandHandler : IRequestHandler<BorrowBookCommand>
    {
        private readonly ILibraryManagementDbContext db;

        public BorrowBookCommandHandler(ILibraryManagementDbContext db)
        {
            this.db = db;
        }

        public async Task Handle(BorrowBookCommand request, CancellationToken cancellationToken)
        {
            Book book = await db.Books.FindAsync(request.Id)
                ?? throw new Exception($"Invalid Book Id: {request.Id}");

            if (book.IsBorrowed == request.IsReturning)
            {
                if (book.IsBorrowed)
                {
                    throw new Exception($"Book is already borrowed");
                }

                book.IsBorrowed = true;
                await db.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception($"Invalid operation. Book status does not match the request.");
            }
        }

    }
}
