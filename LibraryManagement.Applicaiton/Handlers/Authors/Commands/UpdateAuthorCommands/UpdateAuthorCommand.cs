using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Authors.Commands.UpdateAuthorCommands
{
    public class UpdateAuthorCommand : IRequest
    {
        public int Id { get; set; }
        public UpdateAuthorCommandModel? Model { get; set; }
    }
    public class UpdateAuthorCommandModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthYear { get; set; }
    }
}
