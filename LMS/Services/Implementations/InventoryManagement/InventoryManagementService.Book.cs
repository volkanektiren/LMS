using LMS.DTOs.InventoryManagement;
using LMS.Enums;
using LMS.Models.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LMS.Services.Implementations.InventoryManagement
{
    public partial class InventoryManagementService
    {
        public List<BookDTO> GetBooks()
        {
            var books = _context.Books
                .Select(x => new
                {
                    x.Title,
                    x.Author,
                    x.Description, 
                    x.ISBN,
                    x.Publisher,
                    LastStatus = _context.BookStatuses
                        .Where(y => y.BookId.Equals(x.Id))
                        .OrderByDescending(y => y.Created)
                        .Select(y => new
                        {
                            y.Status,
                            y.Created,
                        })
                        .First(),
                })
                .OrderByDescending(x => x.LastStatus.Created)
                .AsEnumerable()
                .Select(x => new BookDTO
                {
                    Title = x.Title,
                    Author = x.Author,
                    Description = x.Description,
                    ISBN = x.ISBN,
                    Publisher = x.Publisher,
                    LastStatus = new BookStatusDTO
                    {
                        Status = x.LastStatus.Status,
                    },
                })
                .ToList();

            return books;
        }

        public void CreateBook(BookDTO dto)
        {
            var bookEntity = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Description = dto.Description,
                ISBN = dto.ISBN,
                Publisher = dto.Publisher,
            };

            var bookStatusEntity = new BookStatus
            {
                Book = bookEntity,
                Status = BookStatusEnum.InLibrary,
                Created = DateTime.Now,
            };

            _context.Books.Add(bookEntity);
            _context.BookStatuses.Add(bookStatusEntity);

            _context.SaveChanges();
        }
    }
}
