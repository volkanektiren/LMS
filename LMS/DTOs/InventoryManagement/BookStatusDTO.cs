using LMS.Enums;
using System;

namespace LMS.DTOs.InventoryManagement
{
    public class BookStatusDTO
    {
        public BookStatusEnum Status { get; set; }
        public DateTime Created { get; set; }
    }
}
