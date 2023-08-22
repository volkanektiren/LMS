using LMS.DTOs.InventoryManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Services.Interfaces
{
    public interface IInventoryManagementService : IBaseService
    {
        List<BookDTO> GetBooks();
        Task CreateBook(BookDTO dto);
        void LendBook(BookLendDTO dto);
    }
}
