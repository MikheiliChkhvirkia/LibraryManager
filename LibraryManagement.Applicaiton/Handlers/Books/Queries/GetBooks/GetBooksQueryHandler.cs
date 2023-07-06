using LibraryManagement.Applicaiton.Common;
using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Application.Tools.Extensions;
using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, PagedData<GetBooksQueryResponse>>
    {
        private readonly ILibraryManagementDbContext db;
        public GetBooksQueryHandler(ILibraryManagementDbContext db)
        {
            this.db = db;
        }
        public async Task<PagedData<GetBooksQueryResponse>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var query = db.Books.Where(b => b.DeleteDate == null);

            if (!string.IsNullOrEmpty(request.Title))
                query = query.Where(b => b.Title!.Contains(request.Title));

            if (!string.IsNullOrEmpty(request.Description))
                query = query.Where(b => b.Description.Contains(request.Description));

            if (request.Rating.HasValue)
                query = query.Where(b => b.Rating == request.Rating.Value);

            if (request.ReleaseDate.HasValue)
                query = query.Where(b => b.ReleaseDate >= request.ReleaseDate.Value);

            if (request.IsBorrowed.HasValue)
                query = query.Where(b => b.IsBorrowed == request.IsBorrowed.Value);

            if (!string.IsNullOrEmpty(request.AuthorFirstName))
                query = query.Where(b => b.Authors.Any(a => a.FirstName.Contains(request.AuthorFirstName)));

            if (!string.IsNullOrEmpty(request.AuthorLastName))
                query = query.Where(b => b.Authors.Any(a => a.LastName.Contains(request.AuthorLastName)));

            if (request.BirthDate.HasValue)
                query = query.Where(b => b.Authors.Any(a => a.BirthYear >= request.BirthDate.Value));

            var result = query.Select(b => new GetBooksQueryResponse()
            {
                Id = b.Id,
                Title = b.Title!,
                Description = b.Description!,
                Rating = b.Rating,
                ReleaseDate = b.ReleaseDate,
                IsBorrowed = b.IsBorrowed,
                FileUrl = b.File.DownloadUrl,
                Authors = b.Authors.Select(a => new GetBooksQueryResponseAuthors
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BirthDate = a.BirthYear
                })
            });

            return result.ToPagedData(request.Page, request.PageSize);
        }

    }
}
