using Microsoft.AspNetCore.Http;

namespace LibraryManagement.FileManager.Models
{
    public class UploadFileRequest
    {
        public IFormFile File { get; set; }
    }
}
