using LMS.Models.Base;
using LMS.Models.VisitorManagement;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.InventoryManagement
{
    [Table("BookLends", Schema = "IM")]
    public class BookLend : BaseEntity
    {
        /// <summary>
        /// Ödünç alınan kitap id
        /// </summary>
        public Guid BookId { get; set; }

        /// <summary>
        /// Kitabı ödünç alan ziyaretçi id
        /// </summary>
        public Guid VisitorId { get; set; }

        /// <summary>
        /// Kitabın ödünç alınma tarihi
        /// </summary>
        public DateTime BorrowDate { get; set; }

        /// <summary>
        /// Kitabın alıcı tarafından vaadedilen geri veriş tarihi
        /// </summary>
        public DateTime? EstimatedReturnDate { get; set; }

        /// <summary>
        /// Kitabın alıcı tarafından geri veriliş tarihi
        /// </summary>
        public DateTime? ReturnDate { get; set; }

        /// <summary>
        /// Kitap geri verildi mi?
        /// </summary>
        public bool IsReturned { get; set; }

        public virtual Book Book { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}
