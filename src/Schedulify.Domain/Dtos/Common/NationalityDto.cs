using Schedulify.Domain.Dtos.Base;

namespace Schedulify.Domain.Dtos.Common;

public class NationalityDto : Dto
{
    public required string Name { get; set; }
    public required string Code { get; set; }
}