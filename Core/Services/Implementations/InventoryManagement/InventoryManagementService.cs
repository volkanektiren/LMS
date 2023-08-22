using Core.Models;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;

namespace Core.Services.Implementations.InventoryManagement
{
    public partial class InventoryManagementService : BaseService, IInventoryManagementService
    {
        private readonly IFileService _fileService;

        public InventoryManagementService(LMSDBContext context, 
            IFileService fileService)
            : base(context)
        {
            _fileService = fileService;
        }
    }
}
