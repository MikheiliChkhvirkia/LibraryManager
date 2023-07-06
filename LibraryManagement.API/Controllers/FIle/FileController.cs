using LibraryManagement.API.Settings.BaseController;
using LibraryManagement.Applicaiton.Handlers.Files.AddFIle;
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
        
    }
}
