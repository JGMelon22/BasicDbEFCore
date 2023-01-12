namespace BasicDatabase_EF.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    // DI
    private readonly IApiRepository _repository;
    public OrdersController(IApiRepository repository)
    {
        _repository = repository;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        var orders = await _repository.GetOrders();

        return orders.Any()
        ? Ok(orders)
        : NoContent();
    }

    // GET By Id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrder(int id)
    {
        var order = await _repository.GetOrder(id);

        return order != null
        ? Ok(order)
        : NotFound("Order not found!");

    }

    // POST
    [HttpPost]
    public async Task<IActionResult> AddOrder(Order order)
    {
        _repository.Add(order);

        return await _repository.SaveAllAsync()
        ? Ok("Order successfully saved!")
        : BadRequest();
    }

    // Due to Business logic, no update to this fella
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var orderToRemove = await _repository.GetOrder(id);

        if (orderToRemove == null)
            return NotFound("Order not found!");

        _repository.Delete(orderToRemove);

        return await _repository.SaveAllAsync()
        ? Ok("Order successfully deleted")
        : BadRequest();
    }
}