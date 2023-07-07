using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Applicaiton.Handlers.Books.Commands.RateBook
{
    public class RateBookCommandHandler : IRequestHandler<RateBookCommand>
    {
        private readonly ILibraryManagementDbContext db;

        public RateBookCommandHandler(ILibraryManagementDbContext db)
        {
            this.db = db;
        }

        public async Task Handle(RateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await db.Books.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeleteDate == null, cancellationToken: cancellationToken)
                ?? throw new Exception($"Invalid Book Id {request.Id}");

            var totalRatings = book.BookRatings.Count;
            var currentRating = book.Rating != 0 ? book.Rating : 0;

            var weightedRating = (currentRating * totalRatings + request.Rating) / (totalRatings + 1);
            var newRating = Math.Sqrt(weightedRating);

            book.Rating = newRating;

            db.BookRatings.Add(new BookRating
            {
                Book = book,
                BookId = request.Id,
                Rate = request.Rating
            });

            await db.SaveChangesAsync(cancellationToken);
        }
    }
}
