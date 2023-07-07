using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.FileManager.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using File = LibraryManagement.Domain.Entities.Files.File;
namespace LibraryManagement.Applicaiton.Handlers.Files.Commands.DeleteFile
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand>
    {
        private readonly ILibraryManagementDbContext db;
        private readonly IFileDeleteService fileDeleteService;
        public DeleteFileCommandHandler(ILibraryManagementDbContext db, IFileDeleteService fileDeleteService)
        {
            this.db = db;
            this.fileDeleteService = fileDeleteService;
        }

        public async Task Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            File file = await db.Files.FirstOrDefaultAsync(f => f.Id == request.FileId, cancellationToken: cancellationToken)
                ?? throw new Exception($"Invalid File Id {request.FileId}");

            file.Delete();
            await fileDeleteService.Delete(file.Name);

            await db.SaveChangesAsync(cancellationToken);
        }
    }
}
