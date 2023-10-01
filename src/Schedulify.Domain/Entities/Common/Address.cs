using Schedulify.Domain.Entities.Base;
using Schedulify.Domain.Entities.Companies;

namespace Schedulify.Domain.Entities.Common;

internal class Address : Entity
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public required int HouseNumber { get; set; }
    public string? HouseNumberAddition { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Fax { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public virtual required Country Country { get; set; }
    public virtual ICollection<CompanyBranchAddress>? CompanyBranchAddresses { get; set; }
}
