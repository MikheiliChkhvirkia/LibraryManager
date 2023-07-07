using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Applicaiton.Handlers.Authors.Commands.UpdateAuthorCommands
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
    {
        private readonly ILibraryManagementDbContext db;
        public UpdateAuthorCommandHandler(ILibraryManagementDbContext db)
        {
            this.db = db;
        }

        public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = await db.Authors.FirstOrDefaultAsync(x => x.Id == request.Id && x.DeleteDate == null, cancellationToken: cancellationToken)
                ?? throw new Exception($"Invalid Author Id: {request.Id}");

            UpdateAuthorProperties(author, request.Model);

            await db.SaveChangesAsync(cancellationToken);
        }

        #region Private 

        private static void UpdateAuthorProperties(Author author, UpdateAuthorCommandModel? request)
        {
            if (!string.IsNullOrEmpty(request.FirstName) && author.FirstName != request.FirstName)
            {
                author.FirstName = request.FirstName;
            }

            if (!string.IsNullOrEmpty(request.LastName) && author.LastName != request.LastName)
            {
                author.LastName = request.LastName;
            }

            if (request.BirthYear.HasValue && author.BirthYear != request.BirthYear.Value)
            {
                author.BirthYear = request.BirthYear.Value;
            }
        }
        #endregion
    }
}
