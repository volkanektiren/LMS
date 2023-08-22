using LMS.DTOs.VisitorManagement;
using LMS.Services.Interfaces;
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

        public IActionResult ListPartial()
        {
            return PartialView("List/_Partial");
        }

        public IActionResult ListTableDataPartial()
        {
            var visitors = _visitorManagementService.GetVisitors();

            return PartialView("List/_TableDataPartial", visitors);
        }

        public IActionResult CreatePartial()
        {
            return PartialView("Create/_Partial");
        }

        [HttpPost]
        public IActionResult Create(VisitorDTO dto)
        {
            _visitorManagementService.CreateVisitor(dto);

            return Json(true);
        }
    }
}
