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

        /// <summary>
        /// Kitap durumu
        /// </summary>
        public BookStatusEnum Status { get; set; }
        /// <summary>
        /// Durumun oluşma tarihi (durum değişikliklerinin historical tutulması için eklendi)
        /// </summary>
        public DateTime Created { get; set; }

        public virtual Book Book { get; set; }
    }
}
