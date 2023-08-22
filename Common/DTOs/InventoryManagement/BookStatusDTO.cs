using Common.Enums;
using System;

namespace Common.DTOs.InventoryManagement
{
    public class BookStatusDTO
    {
        /// <summary>
        /// Kitap durumu
        /// </summary>
        public BookStatusEnum Status { get; set; }
        /// <summary>
        /// Durumun oluşma tarihi
        /// </summary>
        public DateTime Created { get; set; }
    }
}
