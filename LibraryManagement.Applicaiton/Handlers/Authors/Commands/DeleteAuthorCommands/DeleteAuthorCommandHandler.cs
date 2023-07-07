using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Applicaiton.Handlers.Authors.Commands.DeleteAuthorCommands
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly ILibraryManagementDbContext db;

        public DeleteAuthorCommandHandler(ILibraryManagementDbContext db)
        {
            this.db = db;
        }

        public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = await db.Authors.FirstOrDefaultAsync(x => x.Id == request.Id && x.DeleteDate == null, cancellationToken: cancellationToken)
                ?? throw new Exception($"Invalid Author Id: {request.Id}");

            author.Delete();

            await db.SaveChangesAsync(cancellationToken);
        }
    }
}
