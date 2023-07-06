using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Applicaiton.Handlers.Books.Commands.Update
{
    public class UpdateBookCommand : IRequest
    {
        [Required]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool? IsTaken { get; set; }
    }
}
