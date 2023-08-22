using Common.DTOs.Base;

namespace Common.DTOs.ObjectStorage
{
    public class FileDTO : BaseDTO
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

        /// <summary>
        /// Storageda ki fullpath
        /// </summary>
        /// <returns></returns>
        public string GetFullPath()
        {
            return Folder + "/" + Name + "." + Extension;
        }
    }
}
