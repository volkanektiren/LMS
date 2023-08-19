using LMS.Models;
using LMS.Services.Interfaces;

namespace LMS.Services.Implementations.Base
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
