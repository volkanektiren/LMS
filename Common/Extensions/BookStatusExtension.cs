using Common.Enums;

namespace Common.Extensions
{
    public static class BookStatusExtension
    {
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
