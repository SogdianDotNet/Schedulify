namespace Schedulify.Application.Providers;

public interface IClaimsProvider
{
    public Guid? UserId { get; }
}