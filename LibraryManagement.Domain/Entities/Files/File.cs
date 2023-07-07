using LibraryManagement.Domain.Common.Entities;

namespace LibraryManagement.Domain.Entities.Files
{
    public partial class File : TrackedEntity<Guid>
    {
        #region contsructorHelpers

        private const string Url = "https://librarymanagementv1.s3.eu-central-1.amazonaws.com/";

        #endregion
        public File(string name, string extension, string downloadUrl, string mimeType, long lengthInBytes, Guid uniqueId, int fileTypeId)
        {
            Name = name;
            Extension = extension;
            DownloadUrl = Url + downloadUrl;
            MimeType = mimeType;
            LengthInBytes = lengthInBytes;
            UniqueId = uniqueId;
            FileTypeId = fileTypeId;
        }

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
