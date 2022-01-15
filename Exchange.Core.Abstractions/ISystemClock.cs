namespace Exchange.Core;

public interface ISystemClock
{
    DateTime UtcNow { get; }
}