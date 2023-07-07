using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            Book book = await db.Books.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeleteDate == null, cancellationToken: cancellationToken)
                ?? throw new Exception($"Invalid Book Id: {request.Id}");

            UpdateBookProperties(book, request.Model);

            await db.SaveChangesAsync(cancellationToken);
        }

        #region Private 

        private static void UpdateBookProperties(Book book, UpdateBookCommandModel? request)
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
        }
        #endregion
    }
}
