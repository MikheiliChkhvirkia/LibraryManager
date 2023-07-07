using LibraryManagement.API.Settings.BaseController;
using LibraryManagement.Applicaiton.Handlers.Files.Commands.AddFIle;
using LibraryManagement.Applicaiton.Handlers.Files.Commands.DeleteFile;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryManagement.API.Controllers.FIle
{
    public class FileController : ApiControllerBase
    {
        public FileController(IMediator mediator)
        : base(mediator) { }

        [HttpPost("add")]
        [SwaggerOperation("add file")]
        public async Task<Guid> AddFile([FromForm] AddFileCommand request)
            => await mediator.Send(request);

        [HttpDelete("{Id}/delete")]
        [SwaggerOperation("delete file")]
        public async Task DeleteFile(Guid Id)
            => await mediator.Send(new DeleteFileCommand
            {
                FileId = Id
            });
    }
}
