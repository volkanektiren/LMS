using Common.DTOs.InventoryManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IInventoryManagementService : IBaseService
    {
        /// <summary>
        /// Kitaplar getirilir
        /// </summary>
        /// <returns></returns>
        List<BookDTO> GetBooks();
        /// <summary>
        /// Kitap ekleme
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task CreateBook(BookDTO dto);
        /// <summary>
        /// Kitabı ödünç verme
        /// </summary>
        /// <param name="dto"></param>
        void LendBook(BookLendDTO dto);
        /// <summary>
        /// Kitabın ödünç verilme bilgisi
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        BookLendDTO GetLendingDetails(Guid bookId);
        /// <summary>
        /// Kitabı iade alma
        /// </summary>
        /// <param name="lendId"></param>
        void RefundBook(Guid lendId);
    }
}
