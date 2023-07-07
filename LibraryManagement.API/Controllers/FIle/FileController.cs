using LibraryManagement.API.Settings.BaseController;
using LibraryManagement.Applicaiton.Common;
using LibraryManagement.Applicaiton.Handlers.Files.Commands.AddFIle;
using LibraryManagement.Applicaiton.Handlers.Files.Commands.DeleteFile;
using LibraryManagement.Applicaiton.Handlers.Files.Queries.GetFiles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers.FIle
{
    public class FileController : ApiControllerBase
    {
        public FileController(IMediator mediator)
        : base(mediator) { }

        [HttpGet]
        public async Task<PagedData<GetFilesQueryResponse>> AddFile(Guid? Id)
            => await mediator.Send(new GetFilesQuery { FileId = Id });

        [HttpPost("add")]
        public async Task<Guid> AddFile([FromForm] AddFileCommand request)
            => await mediator.Send(request);

        [HttpDelete("{Id}/delete")]
        public async Task DeleteFile(Guid Id)
            => await mediator.Send(new DeleteFileCommand
            {
                FileId = Id
            });
    }
}
