namespace BasicDatabase_EF.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SuppliersController : ControllerBase
{
    // DI
    private readonly IApiRepository _repository;
    public SuppliersController(IApiRepository repository)
    {
        _repository = repository;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> GetSuppliers()
    {
        var suppliers = await _repository.GetSuppliers();

        return suppliers.Any()
        ? Ok(suppliers)
        : NoContent();
    }

    // GET by Id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplier(int id)
    {
        var supplier = await _repository.GetSupplier(id);
        return supplier != null
        ? Ok(supplier)
        : NotFound("Supplier not found!");
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> AddSupplier(Supplier supplier)
    {
        _repository.Add(supplier);

        return await _repository.SaveAllAsync()
        ? Ok("Supplier successfully saved!")
        : BadRequest();
    }

    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSupplier(int id, Supplier supplier)
    {
        var supplierToUpdate = await _repository.GetSupplier(id);
        if (supplierToUpdate == null)
            return NotFound("Supplier not found!");

        supplierToUpdate.CompanyName = supplier.CompanyName;
        supplierToUpdate.ContactName = supplier.ContactName;
        supplierToUpdate.City = supplier.City;
        supplierToUpdate.Country = supplier.Country;
        supplierToUpdate.Phone = supplier.Phone;
        supplierToUpdate.Fax = supplier.Fax;

        return await _repository.SaveAllAsync()
        ? Ok("Supplier successfully updated!")
        : BadRequest();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSupplier(int id)
    {
        var supplierToRemove = await _repository.GetSupplier(id);

        if (supplierToRemove == null)
            return NotFound("Supplier not found!");

        _repository.Delete(supplierToRemove);

        return await _repository.SaveAllAsync()
        ? Ok("Supplier successfully deleted!")
        : BadRequest();

    }
}