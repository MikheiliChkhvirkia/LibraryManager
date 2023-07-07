using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            Book book = await db.Books.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeleteDate == null)
                ?? throw new Exception($"Invalid Book Id: {request.Id}");

            if (book.IsBorrowed == request.IsBorrowing)
                throw new Exception($"Invalid operation. Book status does not match the request.");

            book.IsBorrowed = request.IsBorrowing;
            await db.SaveChangesAsync(cancellationToken);
        }

    }
}
