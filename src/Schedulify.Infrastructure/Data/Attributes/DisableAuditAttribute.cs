using System.Reflection;

namespace Schedulify.Infrastructure.Data.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class DisableAuditAttribute : Attribute
{
    public DisableAuditAttribute()
    {
    }
}

internal static class DisableAuditExtensions
{
    public static bool IsAuditDisabled(this Type from)
    {
        return from.GetCustomAttribute<DisableAuditAttribute>() != null;
    }
}