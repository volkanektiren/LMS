using LMS.DTOs.Base;
using LMS.DTOs.ObjectStorage;
using Microsoft.AspNetCore.Http;

namespace LMS.DTOs.InventoryManagement
{
    public class BookDTO : BaseDTO
    {
        public IFormFile CoverImage { get; set; }
        public FileDTO CoverImageDTO { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public BookStatusDTO LastStatus { get; set; }
    }
}
