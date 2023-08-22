using Common.DTOs.ObjectStorage;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Dosya yükleme
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<FileDTO> UploadFile(IFormFile file);
        /// <summary>
        /// Dosya indirme
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<byte[]> DownloadFile(FileDTO dto);
    }
}
