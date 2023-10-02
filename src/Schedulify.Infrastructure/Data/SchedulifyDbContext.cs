﻿using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Schedulify.Domain.Entities.Companies;
using Schedulify.Domain.Entities.Contracts;
using Schedulify.Domain.Entities.Employees;
using Schedulify.Domain.Entities.Schedules;
using Schedulify.Domain.Entities.Users;

namespace Schedulify.Infrastructure.Data;

internal class SchedulifyDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public SchedulifyDbContext(DbContextOptions<SchedulifyDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public virtual DbSet<Appointment> Appointments { get; set; }
    public virtual DbSet<Contract> Contracts { get; set; }
    public virtual DbSet<Company> Companies { get; set; }
    public virtual DbSet<CompanyBranch> CompanyBranches { get; set; }
    public virtual DbSet<CompanyBranchAddress> CompanyBranchAddresses { get; set; }
    public virtual DbSet<CompanyBranchEmployee> CompanyBranchEmployees { get; set; }
    public virtual DbSet<CompanyBranchSettings> CompanyBranchSettings { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<CompanySettings> CompanySettings { get; set; }
}