using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Areas.InventoryManagement.Controllers
{
    [Area("InventoryManagement")]
    public class BookController : Controller
    {
        private readonly IInventoryManagementService _inventoryManagementService;

        public BookController(IInventoryManagementService inventoryManagementService)
        {
            _inventoryManagementService = inventoryManagementService;
        }

        public IActionResult ListPartial()
        {
            var books = _inventoryManagementService.GetBooks();

            return PartialView("List/_Partial", books);
        }
    }
}
