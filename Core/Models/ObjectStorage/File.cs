using Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.ObjectStorage
{
    [Table("Files", Schema = "OS")]
    public class File : BaseEntity
    {
        /// <summary>
        /// Dosyanın storageda ki directory adı
        /// </summary>
        public string Folder { get; set; }
        /// <summary>
        /// Dosya adı
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Dosya uzantısı
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// Dosya content type
        /// </summary>
        public string ContentType { get; set; }
    }
}
