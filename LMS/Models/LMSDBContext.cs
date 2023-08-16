using Microsoft.EntityFrameworkCore;

namespace LMS.Models
{
    public class LMSDBContext : DbContext
    {
        public LMSDBContext(DbContextOptions<LMSDBContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
