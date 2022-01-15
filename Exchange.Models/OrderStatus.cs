namespace Exchange.Models;

public enum OrderStatus
{
    None = 0,
    New = 1,
    PartiallyFilled = 2,
    Filled = 3,
    Canceled = 4,
    PendingCancel = 5,
    Rejected = 6,
    Expired = 7
}