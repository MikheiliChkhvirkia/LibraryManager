using LibraryManagement.Domain.Common.Entities;

namespace LibraryManagement.Domain.Entities.Files
{
    public partial class FileType : BaseEntity
    {
        public FileType() 
            => Files = new HashSet<File>();
        public int Code { get; set; }
        /// <summary>
        /// A name of the format.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A description of the format.
        /// </summary>
        public string Description { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
