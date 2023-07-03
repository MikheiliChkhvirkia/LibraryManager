using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LibraryManagement.Applicaiton.Persistance
{
    public interface ILibraryManagementDbContext
    {
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
