using MediatR;

namespace LibraryManagement.Applicaiton.Handlers.Books.Commands.Update
{
    public class UpdateBookCommand : IRequest
    {
        public int Id { get; set; }
        public UpdateBookCommandModel? Model { get; set; }
    }
    public sealed class UpdateBookCommandModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
