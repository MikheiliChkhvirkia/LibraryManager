using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Applicaiton.Handlers.Books.Commands.BindAuthorToBook
{
    public class BindAuthorToBookCommandHandler : IRequestHandler<BindAuthorToBookCommand>
    {
        private readonly ILibraryManagementDbContext db;

        public BindAuthorToBookCommandHandler(ILibraryManagementDbContext db)
        {
            this.db = db;
        }

        public async Task Handle(BindAuthorToBookCommand request, CancellationToken cancellationToken)
        {
            Book book = await db.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == request.BookId && b.DeleteDate == null, cancellationToken: cancellationToken)
                ?? throw new Exception($"Invalid Book Id: {request.BookId}");

            Author author = await db.Authors.FirstOrDefaultAsync(b => b.Id == request.AuthorId && b.DeleteDate == null, cancellationToken: cancellationToken)
                ?? throw new Exception($"Invalid Author Id: {request.AuthorId}");

            if (book.Authors?.Any(x => x.Id == request.AuthorId) == true)
                throw new Exception("Book already has this author assigned");

            book.Authors.Add(author);
            await db.SaveChangesAsync(cancellationToken);
        }
    }
}
