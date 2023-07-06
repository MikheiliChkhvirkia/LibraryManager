using Microsoft.AspNetCore.Http;
using LibraryManagement.FileManager.Models;

namespace LibraryManagement.FileManager.Interfaces
{
    public interface IFileUploadService
    {
        Task<FileResponse> UploadAsync(IFormFile file, CancellationToken cancellationToken);
    }
}
