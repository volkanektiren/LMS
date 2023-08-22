using System;
using System.ComponentModel.DataAnnotations.Schema;
using LMS.Models.Base;
using ObjectStorageFile = LMS.Models.ObjectStorage.File;

namespace LMS.Models.InventoryManagement
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
