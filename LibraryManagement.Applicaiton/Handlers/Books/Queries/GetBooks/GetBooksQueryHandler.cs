using LibraryManagement.Applicaiton.Common;
using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Application.Tools.Extensions;
using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, PagedData<GetBooksQueryModel>>
    {
        private readonly ILibraryManagementDbContext db;

        public GetBooksQueryHandler(ILibraryManagementDbContext db)
        {
            this.db = db;
        }

        public async Task<PagedData<GetBooksQueryModel>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return db.Books.Where(b => (request.Id == 0 || b.Id == request.Id) && b.DeleteDate == null)
                .Select(b => new GetBooksQueryModel
                {
                    Id = b.Id,
                    Title = b.Title!,
                    Description = b.Description!,
                    FileUrl = b.File.DeleteDate == null ? b.File.DownloadUrl : null,
                    IsBorrowed = b.IsBorrowed,
                    Rating = b.Rating,
                    ReleaseDate = b.ReleaseDate
                }).ToPagedData(request.Page, request.PageSize);
        }
    }
}
