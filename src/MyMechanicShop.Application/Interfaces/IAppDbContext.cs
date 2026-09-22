using Microsoft.EntityFrameworkCore;
using MyMechanicShop.Domain;
using MyMechanicShop.Domain.Customers;
using MyMechanicShop.Domain.Customers.Vehicles;
using MyMechanicShop.Domain.Employees;
using MyMechanicShop.Domain.Identity;
using MyMechanicShop.Domain.RepairTasks;
using MyMechanicShop.Domain.RepairTasks.Parts;
using MyMechanicShop.Domain.Workorders;
using MyMechanicShop.Domain.Workorders.Billing;

namespace MyMechanicShop.Application.Interfaces;


public interface IAppDbContext
{
    public DbSet<Customer> Customers { get; }
    public DbSet<Part> Parts { get; }
    public DbSet<RepairTask> RepairTasks { get; }
    public DbSet<Vehicle> Vehicles { get; }
    public DbSet<WorkOrder> WorkOrders { get; }
    public DbSet<Employee> Employees { get; }
    public DbSet<Invoice> Invoices { get; }
    public DbSet<RefreshToken> RefreshTokens { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
