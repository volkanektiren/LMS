using Common.DTOs.ObjectStorage;
using Core.Models;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.DataModel;
using Minio.Exceptions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Core.Services.Implementations.File
{
    public class FileService : BaseService, IFileService
    {
        private ILogger<FileService> _logger;
        private IConfiguration Configuration { get; set; }
        private string AccessKey => Configuration["Minio:AccessKey"];
        private string SecretKey => Configuration["Minio:SecretKey"];
        private string Endpoint => Configuration["Minio:Endpoint"];
        private string Bucket => Configuration["Minio:Bucket"];

        private readonly MinioClient _client;

        public FileService(LMSDBContext context,
            ILogger<FileService> logger,
            IConfiguration Configuration) : base(context)
        {
            _logger = logger;
            this.Configuration = Configuration;
            _client = new MinioClient()
                .WithEndpoint(Endpoint)
                .WithCredentials(AccessKey, SecretKey)
                .WithSSL(false)
                .Build();
        }

        public async Task<FileDTO> UploadFile(IFormFile file)
        {
            //Yüklenen dosyanın MemoryStream nesnesini oluşturalım
            MemoryStream stream = new MemoryStream();
            file.CopyTo(stream);
            stream.Position = 0;

            var folder = Guid.NewGuid().ToString();
            var objectName = string.Join('/', folder, file.FileName);

            try
            {
                // bucket kontrolü
                var beArgs = new BucketExistsArgs()
                    .WithBucket(Bucket);
                bool found = await _client.BucketExistsAsync(beArgs);
                if (!found)
                {
                    var mbArgs = new MakeBucketArgs()
                        .WithBucket(Bucket);
                    await _client.MakeBucketAsync(mbArgs);
                }

                // dosyanın bucket a yüklenmesi
                var putObjectArgs = new PutObjectArgs()
                    .WithBucket(Bucket)
                    .WithObject(objectName)
                    .WithStreamData(stream)
                    .WithObjectSize(stream.Length)
                    .WithContentType("application/octet-stream");
                await _client.PutObjectAsync(putObjectArgs);

                await LogObjectStats(objectName);
            }
            catch (MinioException m)
            {
                throw m;
            }

            return new FileDTO
            {
                Folder = folder,
                Name = Path.GetFileNameWithoutExtension(file.FileName),
                Extension = Path.GetExtension(file.FileName).TrimStart('.'),
                ContentType = file.ContentType,
            };
        }

        public async Task<byte[]> DownloadFile(FileDTO dto)
        {
            var objectName = dto.GetFullPath();

            await LogObjectStats(objectName);

            // dosyanın getirilmesi
            byte[] fileBytes = default;
            GetObjectArgs getObjectArgs = new GetObjectArgs()
                .WithBucket(Bucket)
                .WithObject(objectName)
                .WithCallbackStream((stream) =>
                {
                    byte[] buffer = new byte[16 * 1024];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        int read;
                        while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ms.Write(buffer, 0, read);
                        }

                        fileBytes = ms.ToArray();
                    }
                });
            await _client.GetObjectAsync(getObjectArgs);

            return fileBytes;
        }

        private async Task LogObjectStats(string objectName)
        {
            // yüklenmiş dosya bilgilerinin loglanması
            StatObjectArgs statObjectArgs = new StatObjectArgs()
                .WithBucket(Bucket)
                .WithObject(objectName);
            ObjectStat objectStat = await _client.StatObjectAsync(statObjectArgs);
            _logger.Log(LogLevel.Information, objectStat.ObjectName + ": " + objectStat.ETag + " " + objectStat.VersionId + " " + objectStat.ContentType + " " + objectStat.Size);
        }
    }
}
