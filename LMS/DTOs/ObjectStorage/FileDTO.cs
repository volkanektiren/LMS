using LMS.DTOs.Base;
using System;

namespace LMS.DTOs.ObjectStorage
{
    public class FileDTO : BaseDTO
    {
        public string Folder { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }

        public string GetFullPath()
        {
            return Folder + "/" + Name + "." + Extension;
        }
    }
}
