using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Base;
using ObjectStorageFile = Core.Models.ObjectStorage.File;

namespace Core.Models.InventoryManagement
{
    [Table("Books", Schema = "IM")]
    public class Book : BaseEntity
    {
        public Guid CoverImageId { get; set; }
        /// <summary>
        /// Kitap başlığı
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Kitap yazarı
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Kitap resminin storageda ki bilgisi
        /// </summary>
        public ObjectStorageFile CoverImage { get; set; }
    }
}
