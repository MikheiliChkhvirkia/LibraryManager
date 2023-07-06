using LibraryManagement.Applicaiton.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Applicaiton.Handlers.Books.Commands.Delete
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly ILibraryManagementDbContext db;
        public DeleteBookCommandHandler(ILibraryManagementDbContext db)
        {
            this.db = db;
        }
        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await db.Books.FirstOrDefaultAsync(b => b.Id == request.Id)
                ?? throw new Exception($"Invalid Id: {request.Id}");

            book.Delete();

            await db.SaveChangesAsync(cancellationToken);
        }
    }
}
