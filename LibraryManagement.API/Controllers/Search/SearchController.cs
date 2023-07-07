using LibraryManagement.API.Settings.BaseController;
using LibraryManagement.Applicaiton.Common;
using LibraryManagement.Applicaiton.Handlers.Search.Queries.GetSuggestions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers.Search
{
    public class SearchController : ApiControllerBase
    {
        public SearchController(IMediator mediator)
        : base(mediator) { }

        [HttpGet("books-and-authors")]
        public Task<PagedData<GetBooksQueryResponse>> Get([FromQuery] GetSuggestionQuery request)
            => mediator.Send(request);
    }
}
