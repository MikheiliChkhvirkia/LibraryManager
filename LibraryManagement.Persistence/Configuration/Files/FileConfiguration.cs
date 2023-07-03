using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using File = LibraryManagement.Domain.Entities.Files.File;

namespace LibraryManagement.Persistence.Configuration.Files
{
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.ToTable("File");

            builder.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("A date and time the file was created.");

            builder.Property(e => e.DeleteDate)
                .HasColumnType("datetime")
                .HasComment("A date and time the file was deleted.");

            builder.Property(e => e.Extension)
                .IsRequired()
                .HasMaxLength(5)
                .HasComment("An extension of the file.");

            builder.Property(e => e.LengthInBytes).HasComment("A size of the file in bytes.");

            builder.Property(e => e.MimeType)
                .IsRequired()
                .HasComment("A MIME type of the file.");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(260)
                .HasComment("A name of the file.");

            builder.HasOne(d => d.FileType)
                .WithMany(p => p.Files)
                .HasForeignKey(d => d.FileTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_File_FileType");
        }
    }
}
