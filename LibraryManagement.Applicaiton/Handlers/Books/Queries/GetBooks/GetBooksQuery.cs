using LibraryManagement.Applicaiton.Common;
using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Books.Queries.GetBooks
{
    public class GetBooksQuery : IRequest<PagedData<GetBooksQueryResponse>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool? IsBorrowed { get; set; }
        public string? AuthorFirstName { get; set; }
        public string? AuthorLastName { get; set; }
        public DateTime? BirthDate { get; set; }
    }

    public class GetBooksQueryResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool? IsBorrowed { get; set; }
        public string FileUrl { get; set; }
        public IEnumerable<GetBooksQueryResponseAuthors>? Authors { get; set; }

    }
    public class GetBooksQueryResponseAuthors
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
