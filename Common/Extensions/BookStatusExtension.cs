using Common.Enums;

namespace Common.Extensions
{
    public static class BookStatusExtension
    {
        /// <summary>
        /// BookStatusEnum değerlerinin ui daki karşılığı
        /// </summary>
        /// <param name="bookStatusEnum"></param>
        /// <returns></returns>
        public static string ToUIString(this BookStatusEnum bookStatusEnum)
        {
            return bookStatusEnum switch
            {
                BookStatusEnum.Unknown => "Unknown",
                BookStatusEnum.InLibrary => "In Library",
                BookStatusEnum.OutLibrary => "Out Library",
                _ => string.Empty,
            };
        }
    }
}
