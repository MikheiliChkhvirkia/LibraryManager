using LibraryManagement.FileManager.Models;
using Microsoft.AspNetCore.Http;

namespace LibraryManagement.FileManager.Interfaces
{
    public interface IFileUploadService
    {
        Task<FileResponse> UploadAsync(IFormFile file, CancellationToken cancellationToken);
    }
}
