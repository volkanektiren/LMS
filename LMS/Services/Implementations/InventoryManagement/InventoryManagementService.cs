using LMS.Models;
using LMS.Services.Implementations.Base;
using LMS.Services.Interfaces;

namespace LMS.Services.Implementations.InventoryManagement
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
