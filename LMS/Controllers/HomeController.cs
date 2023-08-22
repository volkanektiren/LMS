using Common.DTOs.ObjectStorage;
using Core.Services.Interfaces;
using LMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
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

        /// <summary>
        /// storage dan dosya indirme
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<IActionResult> DownloadFile(FileDTO dto)
        {
            var fileBytes = await _fileService.DownloadFile(dto);

            return File(fileBytes, dto.ContentType);
        }
    }
}
