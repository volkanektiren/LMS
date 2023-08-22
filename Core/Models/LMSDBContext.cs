using Core.Models.InventoryManagement;
using ObjectStorageFile = Core.Models.ObjectStorage.File;
using Core.Models.VisitorManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;
using Microsoft.Extensions.Configuration;
using System;

namespace Core.Models
{
    public class LMSDBContext : DbContext
    {
        private byte[] EncryptionKey { get; set; }
        private byte[] EncryptionIv { get; set; }
        private readonly IEncryptionProvider _encryptionProvider;
        private readonly IConfiguration _configuration;

        public LMSDBContext(DbContextOptions<LMSDBContext> options,
            IConfiguration configuration) : base(options)
        {
            _configuration = configuration;

            EncryptionKey = Convert.FromBase64String(_configuration["Encryption:Key"]);
            EncryptionIv = Convert.FromBase64String(_configuration["Encryption:Iv"]);

            _encryptionProvider = new AesProvider(EncryptionKey, EncryptionIv);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEncryption(_encryptionProvider);
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookStatus> BookStatuses { get; set; }
        public DbSet<BookLend> BookLends { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<ObjectStorageFile> Files { get; set; }
    }
}
