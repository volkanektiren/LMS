using Core.Models;
using Core.Services.Interfaces;

namespace Core.Services.Implementations.Base
{
    public class BaseService : IBaseService
    {
        protected readonly LMSDBContext _context;

        public BaseService(LMSDBContext context) 
        { 
            _context = context;
        }
    }
}
