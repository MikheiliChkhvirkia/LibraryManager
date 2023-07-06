using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Domain.Enums.Files;
using LibraryManagement.FileManager.Interfaces;
using MediatR;
using File = LibraryManagement.Domain.Entities.Files.File;

namespace LibraryManagement.Applicaiton.Handlers.Files.AddFIle
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
            var userProfileFileResponse = await fileUploadService.UploadAsync(request.File!, cancellationToken);

            db.Files.Add(new File(userProfileFileResponse.FileName, 
                userProfileFileResponse.Extension,
                userProfileFileResponse.FileName,
                request.File!.ContentType,
               request.File.Length,
              userProfileFileResponse.UniqueId,
              (byte)FileTypeEnum.Image));

            await db.SaveChangesAsync(cancellationToken);

            return userProfileFileResponse.UniqueId;
        }
    }
}
