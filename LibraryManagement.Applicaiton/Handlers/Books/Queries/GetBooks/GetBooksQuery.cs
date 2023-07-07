using LibraryManagement.Applicaiton.Common;
using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Books.Queries.GetBooks
{
    public class GetBooksQuery : IRequest<PagedData<GetBooksQueryModel>>
    {
        public int Id { get; set; } = 0;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public sealed class GetBooksQueryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileUrl { get; set; }
        public double Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsBorrowed { get; set; }
    }
}
