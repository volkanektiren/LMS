using Common.DTOs.InventoryManagement;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LMS.Areas.InventoryManagement.Controllers
{
    [Area("InventoryManagement")]
    public class BookController : Controller
    {
        private readonly IInventoryManagementService _inventoryManagementService;
        private readonly IVisitorManagementService _visitorManagementService;

        public BookController(IInventoryManagementService inventoryManagementService, 
            IVisitorManagementService visitorManagementService)
        {
            _inventoryManagementService = inventoryManagementService;
            _visitorManagementService = visitorManagementService;
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
        public async Task<IActionResult> Create(BookDTO dto)
        {
            await _inventoryManagementService.CreateBook(dto);

            return Json(true);
        }

        public IActionResult LendPartial(string bookId)
        {
            var visitorFullNames = _visitorManagementService.GetVisitorFullNames();

            ViewBag.BookId = bookId;
            ViewBag.VisitorFullNames = visitorFullNames ?? new Dictionary<Guid, string>();

            return PartialView("Lend/_Partial");
        }

        [HttpPost]
        public IActionResult Lend(BookLendDTO dto)
        {
            _inventoryManagementService.LendBook(dto);
            
            return Json(true);
        }

        public IActionResult LendingDetailsPartial(string bookId)
        {
            var bookGuid = Guid.Parse(bookId);
            var bookLend = _inventoryManagementService.GetLendingDetails(bookGuid);

            return PartialView("Lend/_DetailsPartial", bookLend);
        }

        [HttpPost]
        public IActionResult Refund(string lendId)
        {
            var lendGuid = Guid.Parse(lendId);
            _inventoryManagementService.RefundBook(lendGuid);

            return Json(true);
        }
    }
}
