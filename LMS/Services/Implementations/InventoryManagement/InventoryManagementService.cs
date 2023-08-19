using LMS.Models;
using LMS.Services.Implementations.Base;
using LMS.Services.Interfaces;

namespace LMS.Services.Implementations.InventoryManagement
{
    public partial class InventoryManagementService : BaseService, IInventoryManagementService
    {
        public InventoryManagementService(LMSDBContext context) : base(context)
        {
        }
    }
}
