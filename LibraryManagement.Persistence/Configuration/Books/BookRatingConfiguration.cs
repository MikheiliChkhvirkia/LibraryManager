using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Persistence.Configuration.Books
{
    public class BookRatingConfiguration : IEntityTypeConfiguration<BookRating>
    {
        public void Configure(EntityTypeBuilder<BookRating> builder)
        {
            builder.ToTable("BookRating");

            builder.HasOne(b => b.Book)
                .WithMany(a => a.BookRatings)
                .HasForeignKey(b => b.BookId);
        }
    }
}
