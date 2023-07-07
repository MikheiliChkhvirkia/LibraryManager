using LibraryManagement.Applicaiton.Persistance;
using LibraryManagement.Domain.Common.Contracts;
using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using File = LibraryManagement.Domain.Entities.Files.File;

namespace LibraryManagement.Persistence
{
    public class LibraryManagementDbContext : DbContext, ILibraryManagementDbContext
    {
        public LibraryManagementDbContext(DbContextOptions<LibraryManagementDbContext> options) : base(options) { }
        protected void OnModelCreating(ModelBuilder modelBuilder, Assembly assembly)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<ITrackedEntity>();
            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.UpdateCreateCredentials(DateTime.Now);
                        break;
                    case EntityState.Modified:
                        if (entry.Entity.DeleteDate > DateTime.MinValue)
                        {
                            entry.Entity.UpdateDeleteCredentials(DateTime.Now);
                        }
                        else
                        {
                            entry.Entity.UpdateLastModifiedCredentials(DateTime.Now);
                        }
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        #region Book
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookRating> BookRatings { get; set; }
        #endregion

        #region Author
        public virtual DbSet<Author> Authors { get; set; }
        #endregion

        #region File
        public virtual DbSet<File> Files { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
