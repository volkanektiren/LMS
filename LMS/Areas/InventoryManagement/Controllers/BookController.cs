using Common.DTOs.InventoryManagement;
using Core.Services.Interfaces;
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

        /// <summary>
        /// kitap tablosunu yükler
        /// </summary>
        /// <returns></returns>
        public IActionResult ListPartial()
        {
            return PartialView("List/_Partial");
        }

        /// <summary>
        /// kitap tablo datasını yükler
        /// </summary>
        /// <returns></returns>
        public IActionResult ListTableDataPartial()
        {
            var books = _inventoryManagementService.GetBooks();

            return PartialView("List/_TableDataPartial", books);
        }

        /// <summary>
        /// kitap ekleme formunu yükler
        /// </summary>
        /// <returns></returns>
        public IActionResult CreatePartial()
        {
            return PartialView("Create/_Partial");
        }

        /// <summary>
        /// kitap ekleme post
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(BookDTO dto)
        {
            await _inventoryManagementService.CreateBook(dto);

            return Json(true);
        }

        /// <summary>
        /// kitap ödünç verme formunu yükler
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public IActionResult LendPartial(string bookId)
        {
            var visitorFullNames = _visitorManagementService.GetVisitorFullNames();

            ViewBag.BookId = bookId;
            ViewBag.VisitorFullNames = visitorFullNames ?? new Dictionary<Guid, string>();

            return PartialView("Lend/_Partial");
        }

        /// <summary>
        /// kitap ödünç verme post
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Lend(BookLendDTO dto)
        {
            _inventoryManagementService.LendBook(dto);
            
            return Json(true);
        }

        /// <summary>
        /// kitabın ödünç verilme bilgisini getirir
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public IActionResult LendingDetailsPartial(string bookId)
        {
            var bookGuid = Guid.Parse(bookId);
            var bookLend = _inventoryManagementService.GetLendingDetails(bookGuid);

            return PartialView("Lend/_DetailsPartial", bookLend);
        }

        /// <summary>
        /// kitap iadesi post
        /// </summary>
        /// <param name="lendId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Refund(string lendId)
        {
            var lendGuid = Guid.Parse(lendId);
            _inventoryManagementService.RefundBook(lendGuid);

            return Json(true);
        }
    }
}
