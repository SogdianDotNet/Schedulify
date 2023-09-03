﻿using Schedulify.Domain.Dtos.Base;
using Schedulify.Domain.Dtos.Employees;

namespace Schedulify.Domain.Dtos.Schedules;

public class AppointmentDto : Dto
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Comment { get; set; }
    public DateTime StartDateTimeUtc { get; set; }
    public DateTime EndDateTimeUtc { get; set; }
    public bool IsCanceled { get; set; }
    public DateTime? CancellationDateTimeUtc { get; set; }
    public EmployeeDto? Employee { get; set; }
    public AppointmentTypeDto? AppointmentType { get; set; }
}