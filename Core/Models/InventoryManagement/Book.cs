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
        public string Title { get; set; }
        public string Author { get; set; }

        public ObjectStorageFile CoverImage { get; set; }
    }
}
