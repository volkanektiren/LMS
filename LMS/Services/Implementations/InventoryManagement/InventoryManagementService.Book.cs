using LMS.DTOs.InventoryManagement;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Services.Implementations.InventoryManagement
{
    public partial class InventoryManagementService
    {
        public List<BookDTO> GetBooks()
        {
            var books = _context.Books
                .Select(x => new BookDTO
                {
                    Title = x.Title,
                    Author = x.Author,
                    Description = x.Description,
                    ISBN = x.ISBN,
                    Publisher = x.Publisher,
                })
                .ToList();

            return books;
        }
    }
}
