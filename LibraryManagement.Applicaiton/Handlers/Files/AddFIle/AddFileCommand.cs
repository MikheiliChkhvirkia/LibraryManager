using LibraryManagement.Applicaiton.Common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace LibraryManagement.Applicaiton.Handlers.Files.AddFIle
{
    public class AddFileCommand : IRequest<Guid>
    {
        [AllowedExtensions(new[] { ".png", ".jpg", ".jpeg" }, ErrorMessage = "File must be in PNG, JPG, or JPEG format.")]
        public IFormFile? File { get; set; }
    }
}
