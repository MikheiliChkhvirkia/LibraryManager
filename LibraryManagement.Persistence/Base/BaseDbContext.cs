using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Persistence.Base
{
    public class BaseDBContext : DbContext
    {
        public BaseDBContext(DbContextOptions options)
            : base(options) { }
    }
}