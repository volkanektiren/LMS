using LMS.Models.InventoryManagement;
using ObjectStorageFile = LMS.Models.ObjectStorage.File;
using LMS.Models.VisitorManagement;
using Microsoft.EntityFrameworkCore;

namespace LMS.Models
{
    public class LMSDBContext : DbContext
    {
        public LMSDBContext(DbContextOptions<LMSDBContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookStatus> BookStatuses { get; set; }
        public DbSet<BookLend> BookLends { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<ObjectStorageFile> Files { get; set; }
    }
}
