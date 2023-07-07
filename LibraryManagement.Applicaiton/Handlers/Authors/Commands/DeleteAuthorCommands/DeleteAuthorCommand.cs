using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Authors.Commands.DeleteAuthorCommands
{
    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
