using Common.DTOs.InventoryManagement;
using Common.Enums;
using Core.Models.InventoryManagement;
using ObjectStorageFile = Core.Models.ObjectStorage.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.DTOs.ObjectStorage;

namespace Core.Services.Implementations.InventoryManagement
{
    public partial class InventoryManagementService
    {
        /// <summary>
        /// Kitaplar getirilir
        /// </summary>
        /// <returns></returns>
        public List<BookDTO> GetBooks()
        {
            //kitaplar alfabetik bir şekilde sıralanmış gelir
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

        /// <summary>
        /// Kitap ekleme
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task CreateBook(BookDTO dto)
        {
            //kitap resminin object storage a yüklenmesi
            var coverImageDTO = await _fileService.UploadFile(dto.CoverImage);

            //object storage a yüklenen dosyanın bilgisinin veritabanına kaydedilmesi
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

            //oluşturulan kitabın kütüphane içinde olma durumu kaydı
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
