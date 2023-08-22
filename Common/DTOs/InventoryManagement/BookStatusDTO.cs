using Common.Enums;
using System;

namespace Common.DTOs.InventoryManagement
{
    public class BookStatusDTO
    {
        public BookStatusEnum Status { get; set; }
        public DateTime Created { get; set; }
    }
}
