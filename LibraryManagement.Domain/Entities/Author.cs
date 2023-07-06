using LibraryManagement.Domain.Common.Entities;

namespace LibraryManagement.Domain.Entities
{
    public class Author : TrackedEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthYear { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
