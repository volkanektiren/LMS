using Common.DTOs.VisitorManagement;
using System;
using System.Collections.Generic;

namespace Core.Services.Interfaces
{
    public interface IVisitorManagementService
    {
        /// <summary>
        /// Ziyaretçi bilgileri getirilir
        /// </summary>
        /// <returns></returns>
        List<VisitorDTO> GetVisitors();
        /// <summary>
        /// Ziyaretçi kaydı oluşturma
        /// </summary>
        /// <param name="dto"></param>
        void CreateVisitor(VisitorDTO dto);
        /// <summary>
        /// Ziyaretçilerin isimlerini getirir, select dropdown için
        /// </summary>
        /// <returns></returns>
        Dictionary<Guid, string> GetVisitorFullNames();
    }
}
