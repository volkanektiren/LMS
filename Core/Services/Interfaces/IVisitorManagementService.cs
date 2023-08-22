using Common.DTOs.VisitorManagement;
using System;
using System.Collections.Generic;

namespace Core.Services.Interfaces
{
    public interface IVisitorManagementService
    {
        List<VisitorDTO> GetVisitors();
        void CreateVisitor(VisitorDTO dto);
        Dictionary<Guid, string> GetVisitorFullNames();
    }
}
