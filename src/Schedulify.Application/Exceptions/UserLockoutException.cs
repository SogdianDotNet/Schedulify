namespace Schedulify.Application.Exceptions;

public class UserLockoutException : Exception
{
    public DateTime LockedOutUntilUtc { get; init; }

    public int ExpiresIn => (int)(LockedOutUntilUtc - DateTime.UtcNow).TotalSeconds;

    public UserLockoutException(DateTime lockedOutUntilUtc)
    {
        LockedOutUntilUtc = lockedOutUntilUtc;
    }
}