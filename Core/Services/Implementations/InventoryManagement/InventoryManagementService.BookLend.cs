using Common.DTOs.InventoryManagement;
using Common.DTOs.VisitorManagement;
using Common.Enums;
using Core.Models.InventoryManagement;
using System;
using System.Linq;

namespace Core.Services.Implementations.InventoryManagement
{
    public partial class InventoryManagementService
    {
        /// <summary>
        /// Kitabı ödünç verme
        /// </summary>
        /// <param name="dto"></param>
        public void LendBook(BookLendDTO dto)
        {
            //kitabın ödünç verilme kaydı oluşturulur
            var bookLend = new BookLend
            {
                BookId = dto.BookId,
                VisitorId = dto.VisitorId,
                EstimatedReturnDate = dto.EstimatedReturnDate,
                BorrowDate = DateTime.Now,
            };

            //kitap kütüphane dışına çıktığı için yeni durum kaydı eklenir
            var bookStatus = new BookStatus
            {
                BookId = dto.BookId,
                Status = BookStatusEnum.OutLibrary,
                Created = DateTime.Now,
            };

            _context.BookLends.Add(bookLend);
            _context.BookStatuses.Add(bookStatus);

            _context.SaveChanges();
        }

        /// <summary>
        /// Kitabın ödünç verilme bilgisi
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public BookLendDTO GetLendingDetails(Guid bookId)
        {
            //kitabın ödünç verilme bilgisi getirilir
            var bookLend = _context.BookLends
                .Where(x => x.BookId.Equals(bookId) && !x.IsReturned)
                .OrderByDescending(x => x.BorrowDate)
                .Select(x => new BookLendDTO
                {
                    Id = x.Id,
                    BookId = x.BookId,
                    Visitor = new VisitorDTO
                    {
                        Id = x.Visitor.Id,
                        Name = x.Visitor.Name,
                        Surname = x.Visitor.Surname,
                        Email = x.Visitor.Email,
                        Phone = x.Visitor.Phone,
                    },
                    BorrowDate = x.BorrowDate,
                    EstimatedReturnDate = x.EstimatedReturnDate,
                })
                .FirstOrDefault();

            return bookLend;
        }

        /// <summary>
        /// Kitabı iade alma
        /// </summary>
        /// <param name="lendId"></param>
        public void RefundBook(Guid lendId)
        {
            var bookLend = _context.BookLends
                .Where(x => x.Id.Equals(lendId))
                .FirstOrDefault();

            //kitabın iade edilme tarihi setlenir
            bookLend.ReturnDate = DateTime.Now;

            //kitap geri verildi mi
            bookLend.IsReturned = true;

            //kitap kütüphaneye geri verildiği için durumu eklenir
            var bookStatus = new BookStatus
            {
                BookId = bookLend.BookId,
                Status = BookStatusEnum.InLibrary,
                Created = DateTime.Now,
            };

            _context.BookLends.Update(bookLend);
            _context.BookStatuses.Add(bookStatus);

            _context.SaveChanges();
        }
    }
}
