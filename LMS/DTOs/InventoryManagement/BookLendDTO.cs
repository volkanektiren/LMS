using LMS.DTOs.Base;
using System;

namespace LMS.DTOs.InventoryManagement
{
    public class BookLendDTO : BaseDTO
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
    }
}
