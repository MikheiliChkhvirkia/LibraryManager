using LibraryManagement.Applicaiton.Common;
using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Files.Queries.GetFiles
{
    public class GetFilesQuery : IRequest<PagedData<GetFilesQueryResponse>>
    {
        public Guid? FileId { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public sealed class GetFilesQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DownloadUrl { get; set; }
        public string MimeType { get; set; }
        public string Extension { get; set; }
    }
}
