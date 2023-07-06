using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Books.Commands.AddBookAndAuthors
{
    public class AddBookAndAuthorCommandHandler : IRequestHandler<AddBookAndAuthorsCommand>
    {
        private readonly ILibraryManagementDbContext db;
        public AddBookAndAuthorCommandHandler(ILibraryManagementDbContext db)
        {
            this.db = db;
        }
        public async Task Handle(AddBookAndAuthorsCommand request, CancellationToken cancellationToken)
        {
            var file = db.Files.FirstOrDefault(x => x.UniqueId == request.FileUniqueId)
                ?? throw new Exception($"File : {request.FileUniqueId} does not exist");

            var newBook = new Book
            {
                Title = request.Title,
                Description = request.Description,
                ReleaseDate = request.ReleaseDate,
                IsBorrowed = request.IsTaken,
                FileId = file.Id,
                Authors = request.Authors?.Select(x => new Author
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthYear = x.BirthDate
                }).ToList()
            };

            db.Books.Add(newBook);

            await db.SaveChangesAsync(cancellationToken);
        }
    }
}
