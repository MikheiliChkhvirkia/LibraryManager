using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using File = LibraryManagement.Domain.Entities.Files.File;

namespace LibraryManagement.Applicaiton.Persistance
{
    public interface ILibraryManagementDbContext
    {
        #region Book
        DbSet<Book> Books { get; set; }
        DbSet<BookRating> BookRatings { get; set; }
        #endregion

        #region Author
        DbSet<Author> Authors { get; set; }
        #endregion

        #region File
        DbSet<File> Files { get; set; }
        #endregion
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
