using LMS.DTOs.Base;

namespace LMS.DTOs.InventoryManagement
{
    public class BookDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
    }
}
