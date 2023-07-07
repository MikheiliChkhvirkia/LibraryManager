using LibraryManagement.Domain.Common.Entities;

namespace LibraryManagement.Domain.Entities
{
    public class BookRating : TrackedEntity
    {
        public int BookId { get; set; }
        public int Rate { get; set; }

        public virtual Book Book { get; set; }
    }
}
