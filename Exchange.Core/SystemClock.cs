namespace Exchange.Core;

internal class SystemClock : ISystemClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}