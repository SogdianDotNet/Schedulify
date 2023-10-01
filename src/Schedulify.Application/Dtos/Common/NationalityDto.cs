using Schedulify.Application.Dtos.Base;

namespace Schedulify.Application.Dtos.Common;

public class NationalityDto : Dto
{
    public required string Name { get; set; }
    public required string Code { get; set; }
}