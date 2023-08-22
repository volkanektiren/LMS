using LMS.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.ObjectStorage
{
    [Table("Files", Schema = "OS")]
    public class File : BaseEntity
    {
        public string Folder { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
    }
}
