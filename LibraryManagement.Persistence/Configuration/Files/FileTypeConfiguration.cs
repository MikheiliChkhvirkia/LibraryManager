using LibraryManagement.Domain.Entities.Files;
using LibraryManagement.Domain.Enums.Files;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Persistence.Configuration.Files
{
    public class FileTypeConfiguration : IEntityTypeConfiguration<FileType>
    {
        public void Configure(EntityTypeBuilder<FileType> builder)
        {
            builder.ToTable("FileType");

            builder.Property(e => e.Id).HasComment("A uniquie identifier.");

            builder.Property(e => e.Description).HasComment("A description of the format.");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("A name of the format.");


            builder.HasData(
                new FileType
                {
                    Id = (int)FileTypeEnum.Image,
                    Name = "Image",
                    Description = "სურათი"
                }
            );
        }
    }
}
