using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Authors.Queries.GetAuthorsQuerys
{
    public class GetAuthorsQuery : IRequest<List<GetAuthorsQueryResposne>>
    {
        public string FilterText { get; set; }
        public DateTime BirtYear { get; set; }
    }

    public class GetAuthorsQueryResposne
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
