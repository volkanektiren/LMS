using Common.DTOs.VisitorManagement;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Areas.VisitorManagement.Controllers
{
    [Area("VisitorManagement")]
    public class VisitorController : Controller
    {
        private readonly IVisitorManagementService _visitorManagementService;

        public VisitorController(IVisitorManagementService visitorManagementService)
        {
            _visitorManagementService = visitorManagementService;
        }

        /// <summary>
        /// ziyaretçi tablosunu yükler
        /// </summary>
        /// <returns></returns>
        public IActionResult ListPartial()
        {
            return PartialView("List/_Partial");
        }

        /// <summary>
        /// ziyaretçi tablo datasını yükler
        /// </summary>
        /// <returns></returns>
        public IActionResult ListTableDataPartial()
        {
            var visitors = _visitorManagementService.GetVisitors();

            return PartialView("List/_TableDataPartial", visitors);
        }

        /// <summary>
        /// ziyaretçi ekleme formunu yükler
        /// </summary>
        /// <returns></returns>
        public IActionResult CreatePartial()
        {
            return PartialView("Create/_Partial");
        }

        /// <summary>
        /// ziyaretçi ekleme post
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(VisitorDTO dto)
        {
            _visitorManagementService.CreateVisitor(dto);

            return Json(true);
        }
    }
}
