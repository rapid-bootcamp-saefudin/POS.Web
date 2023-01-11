using Microsoft.EntityFrameworkCore;
using POS.Repository;

namespace POS.Repository
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) 
        { 

        }

        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<SupplierEntity> Suppliers => Set<SupplierEntity>();    
        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
        public DbSet<ShipperEntity> Shippers => Set<ShipperEntity>();
        public DbSet<EmployeeEntity> Employees => Set<EmployeeEntity>();
        public DbSet<OrderEntity> Orders => Set<OrderEntity>();
        public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    }
}