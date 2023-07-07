using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Enums.Files;
using LibraryManagement.FileManager.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using File = LibraryManagement.Domain.Entities.Files.File;

namespace LibraryManagement.Applicaiton.Handlers.Files.Commands.AddFIle
{
    public class AddFileCommandHandler : IRequestHandler<AddFileCommand, Guid>
    {
        private readonly ILibraryManagementDbContext db;
        private readonly IFileUploadService fileUploadService;
        public AddFileCommandHandler(ILibraryManagementDbContext db, IFileUploadService fileUploadService)
        {
            this.db = db;
            this.fileUploadService = fileUploadService;
        }
        public async Task<Guid> Handle(AddFileCommand request, CancellationToken cancellationToken)
        {
            Book? book = null;

            if (request.BookId != null)
            {
                book = await db.Books.FirstOrDefaultAsync(b => b.Id == request.BookId && b.DeleteDate == null, cancellationToken)
                    ?? throw new Exception($"Invalid Book id: {request.BookId}");
            }

            var userProfileFileResponse = await fileUploadService.UploadAsync(request.File!, cancellationToken);

            var file = new File(
                name: userProfileFileResponse.FileName,
                extension: userProfileFileResponse.Extension,
                downloadUrl: userProfileFileResponse.FileName,
                mimeType: request.File!.ContentType,
                lengthInBytes: request.File.Length,
                uniqueId: userProfileFileResponse.UniqueId,
                fileTypeId: (int)FileTypeEnum.Image
            );

            if (book != null)
            {
                book.File = file;
            }

            db.Files.Add(file);
            await db.SaveChangesAsync(cancellationToken);

            return userProfileFileResponse.UniqueId;
        }

    }
}
