using LibraryManagement.Domain.Common.Entities;
using File = LibraryManagement.Domain.Entities.Files.File;

namespace LibraryManagement.Domain.Entities
{
    public class Book : TrackedEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid? FileId { get; set; }
        public double Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool IsBorrowed { get; set; }

        public virtual File File { get; set; }
        public virtual ICollection<Author>? Authors { get; set; }
        public virtual ICollection<BookRating>? BookRatings { get; set; }
    }
}
