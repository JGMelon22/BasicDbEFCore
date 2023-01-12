using BasicDatabase_EF.Dots;

namespace BasicDatabase_EF.Interfaces;

public interface IApiRepository
{
    void Add<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    void Update<T>(T entity) where T : class;
    Task<bool> SaveAllAsync();
    Task<IEnumerable<Customer>> GetCustomers();
    Task<Customer> GetCustomer(int id);
    Task<IEnumerable<Order>> GetOrders();
    Task<Order> GetOrder(int id);
    Task<IEnumerable<OrderItem>> GetOrderItems();
    Task<OrderItem> GetOrderItem(int id);
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProduct(int id);
    Task<IEnumerable<Supplier>> GetSuppliers();
    Task<Supplier> GetSupplier(int id);
}