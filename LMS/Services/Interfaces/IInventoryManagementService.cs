using LMS.DTOs.InventoryManagement;
using System.Collections.Generic;

namespace LMS.Services.Interfaces
{
    public interface IInventoryManagementService : IBaseService
    {
        List<BookDTO> GetBooks();
        void CreateBook(BookDTO dto);
        void LendBook(BookLendDTO dto);
    }
}
