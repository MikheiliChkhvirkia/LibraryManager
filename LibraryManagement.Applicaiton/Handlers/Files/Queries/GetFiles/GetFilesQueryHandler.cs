using LibraryManagement.Applicaiton.Common;
using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Application.Tools.Extensions;
using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Files.Queries.GetFiles
{
    public class GetFilesQueryHandler : IRequestHandler<GetFilesQuery, PagedData<GetFilesQueryResponse>>
    {
        private readonly ILibraryManagementDbContext db;

        public GetFilesQueryHandler(ILibraryManagementDbContext db)
        {
            this.db = db;
        }

        public async Task<PagedData<GetFilesQueryResponse>> Handle(GetFilesQuery request, CancellationToken cancellationToken)
            => db.Files.Where(f => (request.FileId == null || request.FileId == f.Id) && f.DeleteDate == null).Select(f => new GetFilesQueryResponse
            {
                Id = f.Id,
                Extension = f.Extension,
                DownloadUrl = f.DownloadUrl,
                MimeType = f.MimeType,
                Name = f.Name,
            }).ToPagedData(request.Page, request.PageSize);
    }
}
