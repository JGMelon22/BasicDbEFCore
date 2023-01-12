namespace BasicDatabase_EF.Repositories;

public class ApiRepository : IApiRepository
{
    // DI 
    private readonly AppDbContext _context;
    public ApiRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public async Task<Customer> GetCustomer(int id)
    {
        var customer = await _context.Customers
       .Where(x => x.CustomerId == id)
       .FirstOrDefaultAsync();

        return customer;
    }

    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        return await _context.Customers.AsNoTracking().ToListAsync();
    }

    public async Task<Order> GetOrder(int id)
    {
        var order = await _context.Orders
        .Where(x => x.OrderId == id)
        .FirstOrDefaultAsync();

        return order;
    }

    public async Task<OrderItem> GetOrderItem(int id)
    {
        var orderItem = await _context.OrderItems
        .Where(x => x.OrderItemId == id)
        .FirstOrDefaultAsync();

        return orderItem;
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItems()
    {
        return await _context.OrderItems.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetOrders()
    {
        return await _context.Orders.AsNoTracking().ToListAsync();
    }

    public async Task<Product> GetProduct(int id)
    {
        var product = await _context.Products
        .Where(x => x.ProductId == id)
        .FirstOrDefaultAsync();

        return product;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Supplier> GetSupplier(int id)
    {
        var supplier = await _context.Suppliers
        .Where(x => x.SupplierId == id)
        .FirstOrDefaultAsync();
        return supplier;
    }

    public async Task<IEnumerable<Supplier>> GetSuppliers()
    {
        return await _context.Suppliers.AsNoTracking().ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Update(entity);
    }
}