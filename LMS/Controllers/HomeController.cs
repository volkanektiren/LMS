using Common.DTOs.ObjectStorage;
using LMS.Models;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    public class HomeController : Controller
    {
        private IFileService _fileService;

        public HomeController(IFileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> DownloadFile(FileDTO dto)
        {
            var fileBytes = await _fileService.DownloadFile(dto);

            return File(fileBytes, dto.ContentType);
        }
    }
}
