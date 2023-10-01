using Schedulify.Application.Dtos.Base;
using Schedulify.Application.Dtos.Finances;

namespace Schedulify.Application.Dtos.Schedules;

public class AppointmentTypeDto : Dto
{
    public required string Name { get; set; }
    public List<AppointmentDto>? Appointments { get; set; } = new();
    public List<PriceDto>? Prices { get; set; } = new();
}