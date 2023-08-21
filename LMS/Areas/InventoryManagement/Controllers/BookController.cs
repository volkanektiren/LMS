using LMS.DTOs.InventoryManagement;
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
            return PartialView("List/_Partial");
        }

        public IActionResult ListTableDataPartial()
        {
            var books = _inventoryManagementService.GetBooks();

            return PartialView("List/_TableDataPartial", books);
        }

        public IActionResult CreatePartial()
        {
            return PartialView("Create/_Partial");
        }

        [HttpPost]
        public IActionResult Create(BookDTO dto)
        {
            _inventoryManagementService.CreateBook(dto);

            return Json(true);
        }
    }
}
