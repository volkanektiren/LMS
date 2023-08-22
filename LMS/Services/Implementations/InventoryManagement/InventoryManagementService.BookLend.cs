using LMS.DTOs.InventoryManagement;
using LMS.Enums;
using LMS.Models.InventoryManagement;
using System;

namespace LMS.Services.Implementations.InventoryManagement
{
    public partial class InventoryManagementService
    {
        public void LendBook(BookLendDTO dto)
        {
            var bookLend = new BookLend
            {
                BookId = dto.BookId,
                VisitorId = dto.VisitorId,
                EstimatedReturnDate = dto.EstimatedReturnDate,
                BorrowDate = DateTime.Now,
            };

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
    }
}
