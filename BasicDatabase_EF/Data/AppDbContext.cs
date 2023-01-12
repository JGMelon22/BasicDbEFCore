namespace BasicDatabase_EF.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    // Fluent API 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Supplier>()
            .HasOne(x => x.Product)
            .WithOne(y => y.Supplier)
            .HasForeignKey<Product>(z => z.SupplierId);

        modelBuilder.Entity<Order>()
            .HasOne(x => x.Customer)
            .WithMany(y => y.Orders)
            .HasForeignKey(z => z.CustomerId);

        modelBuilder.Entity<OrderItem>()
            .HasKey(x => new { x.OrderId, x.ProductId });
        modelBuilder.Entity<OrderItem>()
            .HasOne(x => x.Order)
            .WithMany(y => y.OrderItems)
            .HasForeignKey(x => x.OrderId);
        modelBuilder.Entity<OrderItem>()
            .HasOne(x => x.Product)
            .WithMany(y => y.OrderItems)
            .HasForeignKey(x => x.ProductId);

    }


    // DBSets
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
}