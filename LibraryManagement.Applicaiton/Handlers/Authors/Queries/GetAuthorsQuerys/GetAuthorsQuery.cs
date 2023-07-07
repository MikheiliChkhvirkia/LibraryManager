using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Authors.Queries.GetAuthorsQuerys
{
    public class GetAuthorsQuery : IRequest<List<GetAuthorsQueryResponse>>
    {
        public string FilterText { get; set; }
        public DateTime BirtYear { get; set; }
    }

    public class GetAuthorsQueryResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
