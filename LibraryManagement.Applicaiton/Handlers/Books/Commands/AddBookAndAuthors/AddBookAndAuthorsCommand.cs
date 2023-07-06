using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Applicaiton.Handlers.Books.Commands.AddBookAndAuthors
{
    public class AddBookAndAuthorsCommand : IRequest
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Release date is required.")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public bool IsTaken { get; set; }

        [Required]
        public Guid FileUniqueId { get; set; }

        public List<AuthorModel> Authors { get; set; }
    }

    public sealed class AuthorModel
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        public DateTime BirthDate { get; set; }
    }
}
