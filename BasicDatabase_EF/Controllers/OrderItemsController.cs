namespace BasicDatabase_EF.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderItemsController : ControllerBase
{
    // DI
    private readonly IApiRepository _repository;
    public OrderItemsController(IApiRepository repository)
    {
        _repository = repository;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> GetOrderItems()
    {
        var orderItems = await _repository.GetOrderItems();

        return orderItems != null
            ? Ok(orderItems)
            : NoContent();
    }

    // GET by Id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderItem(int id)
    {
        var orderItem = await _repository.GetOrderItem(id);

        return orderItem != null
        ? Ok(orderItem)
        : NotFound("Order Item not found!");
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> AddOrderItem(OrderItem orderItem)
    {
        _repository.Add(orderItem);

        return await _repository.SaveAllAsync()
        ? Ok("Order Item successfully added!")
        : BadRequest();
    }

    // PATCH
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateOrderItem(int id, OrderItem orderItem)
    {
        var orderItemToUpdate = await _repository.GetOrderItem(id);
        if (orderItemToUpdate == null)
            return NotFound("Order Item not found!");

        orderItemToUpdate.UnitPrice = orderItem.UnitPrice;

        return await _repository.SaveAllAsync()
        ? Ok("Order Item successfully saved!")
        : BadRequest();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrderItem(int id)
    {
        var orderItemToRemove = await _repository.GetOrderItem(id);

        if (orderItemToRemove == null)
            return NotFound("Order Item not found!");

        _repository.Delete(orderItemToRemove);

        return await _repository.SaveAllAsync()
        ? Ok("Order Item successfully deleted!")
        : BadRequest();
    }
}