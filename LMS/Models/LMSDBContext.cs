using LMS.Models.InventoryManagement;
using LMS.Models.VisitorManagement;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace LMS.Models
{
    public class LMSDBContext : DbContext
    {
        public LMSDBContext(DbContextOptions<LMSDBContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookStatus> BookStatuses { get; set; }
        public DbSet<BookBorrow> BookBorrows { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
