using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Books.Commands.Update
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly ILibraryManagementDbContext db;
        public UpdateBookCommandHandler(ILibraryManagementDbContext db)
        {
            this.db = db;
        }
        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            Book book = await db.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken)
                ?? throw new Exception($"Invalid Id: {request.Id}");

            UpdateBookProperties(book, request);

            await db.SaveChangesAsync(cancellationToken);
        }

        #region Private 

        private static void UpdateBookProperties(Book book, UpdateBookCommand request)
        {
            if (!string.IsNullOrEmpty(request.Title) && book.Title != request.Title)
            {
                book.Title = request.Title;
            }

            if (!string.IsNullOrEmpty(request.Description) && book.Description != request.Description)
            {
                book.Description = request.Description;
            }

            if (request.ReleaseDate.HasValue && book.ReleaseDate != request.ReleaseDate.Value)
            {
                book.ReleaseDate = request.ReleaseDate.Value;
            }

            if (request.IsTaken.HasValue && book.IsBorrowed != request.IsTaken.Value)
            {
                book.IsBorrowed = request.IsTaken.Value;
            }
        }
        #endregion
    }
}
