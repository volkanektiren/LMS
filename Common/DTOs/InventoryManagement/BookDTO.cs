using Common.DTOs.Base;
using Common.DTOs.ObjectStorage;
using Microsoft.AspNetCore.Http;

namespace Common.DTOs.InventoryManagement
{
    public class BookDTO : BaseDTO
    {
        /// <summary>
        /// Kitap eklerken upload edilen resim
        /// </summary>
        public IFormFile CoverImage { get; set; }
        /// <summary>
        /// Kitap resmi bilgisi
        /// </summary>
        public FileDTO CoverImageDTO { get; set; }
        /// <summary>
        /// Kitap başlığı
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Kitap yazarı
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Kitabın güncel durumu
        /// </summary>
        public BookStatusDTO LastStatus { get; set; }
    }
}
