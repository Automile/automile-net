namespace Automile.Net
{
    public enum ApiTripType : byte
    {
        Business = 0,        
        Personal = 1,        
        Other = 2,
        Auto = 3
    }

    public enum ApiTripTypeTrigger : byte
    {
        Start = 0,
        End = 1,
        DrivesBetween = 2,
    }
}
