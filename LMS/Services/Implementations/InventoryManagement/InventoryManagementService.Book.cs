using LMS.DTOs.InventoryManagement;
using LMS.Enums;
using LMS.Models.InventoryManagement;
using ObjectStorageFile = LMS.Models.ObjectStorage.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LMS.DTOs.ObjectStorage;

namespace LMS.Services.Implementations.InventoryManagement
{
    public partial class InventoryManagementService
    {
        public List<BookDTO> GetBooks()
        {
            var books = _context.Books
                .Include(x => x.CoverImage)
                .Select(x => new
                {
                    x.Id,
                    x.CoverImage,
                    x.Title,
                    x.Author,
                    LastStatus = _context.BookStatuses
                        .Where(y => y.BookId.Equals(x.Id))
                        .OrderByDescending(y => y.Created)
                        .Select(y => new
                        {
                            y.Status,
                        })
                        .First(),
                })
                .OrderBy(x => x.Title)
                .AsEnumerable()
                .Select(x => new BookDTO
                {
                    Id = x.Id,
                    CoverImageDTO = new FileDTO
                    {
                        Folder = x.CoverImage.Folder,
                        Name = x.CoverImage.Name,
                        Extension = x.CoverImage.Extension,
                        ContentType = x.CoverImage.ContentType,
                    },
                    Title = x.Title,
                    Author = x.Author,
                    LastStatus = new BookStatusDTO
                    {
                        Status = x.LastStatus.Status,
                    },
                })
                .ToList();

            return books;
        }

        public async Task CreateBook(BookDTO dto)
        {
            var coverImageDTO = await _fileService.UploadFile(dto.CoverImage);

            var coverImage = new ObjectStorageFile
            {
                Folder = coverImageDTO.Folder,
                Name = coverImageDTO.Name,
                Extension = coverImageDTO.Extension,
                ContentType = coverImageDTO.ContentType,
            };

            var book = new Book
            {
                CoverImage = coverImage,
                Title = dto.Title,
                Author = dto.Author,
            };

            var bookStatus = new BookStatus
            {
                Book = book,
                Status = BookStatusEnum.InLibrary,
                Created = DateTime.Now,
            };

            await _context.Files.AddAsync(coverImage);
            await _context.Books.AddAsync(book);
            await _context.BookStatuses.AddAsync(bookStatus);

            await _context.SaveChangesAsync();
        }
    }
}
