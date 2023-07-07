using LibraryManagement.Applicaiton.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Applicaiton.Handlers.Authors.Queries.GetAuthorsQuerys
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<GetAuthorsQueryResponse>>
    {
        private readonly ILibraryManagementDbContext db;
        public GetAuthorsQueryHandler(ILibraryManagementDbContext db)
        {
            this.db = db;
        }

        public async Task<List<GetAuthorsQueryResponse>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
            => await db.Authors
                .Where(a => a.DeleteDate == null &&
                            (string.IsNullOrEmpty(request.FilterText) ||
                            a.FirstName.Contains(request.FilterText) ||
                            a.LastName.Contains(request.FilterText)) &&
                            (request.BirtYear == default || a.BirthYear >= request.BirtYear))
                .Select(a => new GetAuthorsQueryResponse
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    BirthDate = a.BirthYear
                })
                .ToListAsync(cancellationToken);

    }
}
