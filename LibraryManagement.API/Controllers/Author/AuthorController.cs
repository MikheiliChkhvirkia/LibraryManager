using LibraryManagement.API.Settings.BaseController;
using LibraryManagement.Applicaiton.Handlers.Authors.Commands.DeleteAuthorCommands;
using LibraryManagement.Applicaiton.Handlers.Authors.Commands.UpdateAuthorCommands;
using LibraryManagement.Applicaiton.Handlers.Authors.Queries.GetAuthorsQuerys;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers.Author
{
    public class AuthorController : ApiControllerBase
    {
        public AuthorController(IMediator mediator)
        : base(mediator) { }

        [HttpGet]
        public Task<List<GetAuthorsQueryResposne>> GetAuthor([FromQuery] GetAuthorsQuery request)
            => mediator.Send(request);

        [HttpPatch("{Id}/update")]
        public Task UpdateAuthor(int Id, [FromBody] UpdateAuthorCommandModel request)
            => mediator.Send(new UpdateAuthorCommand
            {
                Id = Id,
                Model = request
            });

        [HttpDelete("{Id}/Delete")]
        public Task DeleteAuthor(int Id)
            => mediator.Send(new DeleteAuthorCommand { Id = Id });
    }
}
