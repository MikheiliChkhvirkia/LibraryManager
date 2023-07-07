namespace LibraryManagement.FileManager.Interfaces
{
    public interface IFileDeleteService
    {
        Task Delete(string fileName);
    }
}
