using LibraryManagement.Applicaiton.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Applicaiton.Handlers.Files.Commands.AddFIle
{
    public class AddFileCommand : IRequest<Guid>
    {
        public int? BookId { get; set; }

        [Required]
        [AllowedExtensions(new[] { ".png", ".jpg", ".jpeg" }, ErrorMessage = "File must be in PNG, JPG, or JPEG format.")]
        public IFormFile File { get; set; }

    }
}
