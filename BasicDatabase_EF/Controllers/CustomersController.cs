namespace BasicDatabase_EF.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    // DI
    private readonly IApiRepository _repository;
    public CustomersController(IApiRepository repository)
    {
        _repository = repository;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _repository.GetCustomers();
        return customers.Any()
        ? Ok(customers)
        : NoContent();
    }

    // GET by Id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomer(int id)
    {
        var customer = await _repository.GetCustomer(id);

        return customer != null
        ? Ok(customer)
        : NotFound("Customer not found!");
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(Customer customer)
    {
        _repository.Add(customer);

        return await _repository.SaveAllAsync()
        ? Ok("Customer successfully saved!")
        : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
    {
        var customerToUpdate = await _repository.GetCustomer(id);
        if (customerToUpdate == null)
            return NotFound("Customer not found!");

        customerToUpdate.FirstName = customer.FirstName;
        customerToUpdate.LastName = customer.LastName;
        customerToUpdate.City = customer.City;
        customerToUpdate.Country = customer.Country;
        customerToUpdate.Phone = customer.Phone;

        return await _repository.SaveAllAsync()
        ? Ok("Customer successfully updated!")
        : BadRequest();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customerToRemove = await _repository.GetCustomer(id);

        if (customerToRemove == null)
            return NotFound("Customer not found!");

        _repository.Delete(customerToRemove);

        return await _repository.SaveAllAsync()
        ? Ok("Customer successfully deleted!")
        : BadRequest();
    }
}