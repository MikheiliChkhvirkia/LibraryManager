using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Files.Commands.DeleteFile
{
    public class DeleteFileCommand : IRequest
    {
        public Guid FileId { get; set; }
    }
}
