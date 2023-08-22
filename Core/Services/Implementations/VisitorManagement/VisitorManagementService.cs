using Common.DTOs.VisitorManagement;
using Core.Models;
using Core.Models.VisitorManagement;
using Core.Services.Implementations.Base;
using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services.Implementations.VisitorManagement
{
    public class VisitorManagementService : BaseService, IVisitorManagementService
    {
        public VisitorManagementService(LMSDBContext context) : base(context)
        {
        }

        /// <summary>
        /// Ziyaretçi bilgileri getirilir
        /// </summary>
        /// <returns></returns>
        public List<VisitorDTO> GetVisitors()
        {
            var visitors = _context.Visitors
                .Select(x => new VisitorDTO
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    Email = x.Email,
                    Phone = x.Phone,
                    BirthDate = x.BirthDate,
                })
                .ToList();

            return visitors;
        }

        /// <summary>
        /// Ziyaretçi kaydı oluşturma
        /// </summary>
        /// <param name="dto"></param>
        public void CreateVisitor(VisitorDTO dto)
        {
            var visitorEntity = new Visitor
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                Phone = dto.Phone,
                BirthDate = dto.BirthDate,
            };

            _context.Visitors.Add(visitorEntity);

            _context.SaveChanges();
        }

        /// <summary>
        /// Ziyaretçilerin isimlerini getirir, select dropdown için
        /// </summary>
        /// <returns></returns>
        public Dictionary<Guid, string> GetVisitorFullNames()
        {
            var visitorFullNames = _context.Visitors
                .Select(x => new 
                { 
                    x.Id,
                    x.Name,
                    x.Surname,
                })
                .AsEnumerable()
                .Select(x => new
                {
                    x.Id,
                    FullName = string.Join(' ', x.Name, x.Surname),
                })
                .ToDictionary(x => x.Id, x => x.FullName);

            return visitorFullNames;
        }
    }
}
