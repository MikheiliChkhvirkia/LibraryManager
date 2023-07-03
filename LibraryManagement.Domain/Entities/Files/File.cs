using LibraryManagement.Domain.Common.Entities;

namespace LibraryManagement.Domain.Entities.Files
{
    public partial class File : TrackedEntity<Guid>
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string DownloadUrl { get; set; }
        public string MimeType { get; set; }
        public long LengthInBytes { get; set; }
        public Guid UniqueId { get; set; }

        public int FileTypeId { get; set; }

        public virtual Book Book { get; set; }
        public virtual FileType FileType { get; set; }
    }
}
