using Common.DTOs.ObjectStorage;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace LMS.Services.Interfaces
{
    public interface IFileService
    {
        Task<FileDTO> UploadFile(IFormFile file);
        Task<byte[]> DownloadFile(FileDTO dto);
    }
}
