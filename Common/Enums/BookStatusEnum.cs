namespace Common.Enums
{
    public enum BookStatusEnum : byte
    {
        //Durumu bilinmiyor
        Unknown = 0,
        //Kütüphane içinde
        InLibrary = 1, 
        //Kütüphane dışında
        OutLibrary = 2
    }
}
