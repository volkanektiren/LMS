using Common.DTOs.ObjectStorage;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IFileService
    {
        Task<FileDTO> UploadFile(IFormFile file);
        Task<byte[]> DownloadFile(FileDTO dto);
    }
}
