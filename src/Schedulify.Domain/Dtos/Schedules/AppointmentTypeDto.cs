using Schedulify.Domain.Dtos.Base;
using Schedulify.Domain.Dtos.Finances;

namespace Schedulify.Domain.Dtos.Schedules;

public class AppointmentTypeDto : Dto
{
    public required string Name { get; set; }
    public List<AppointmentDto>? Appointments { get; set; } = new();
    public List<PriceDto>? Prices { get; set; } = new();
}