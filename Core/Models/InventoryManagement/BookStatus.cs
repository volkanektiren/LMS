using Common.Enums;
using Core.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.InventoryManagement
{
    [Table("BookStatuses", Schema = "IM")]
    public class BookStatus : BaseEntity
    {
        public Guid BookId { get; set; }

        public BookStatusEnum Status { get; set; }
        public DateTime Created { get; set; }

        public virtual Book Book { get; set; }
    }
}
