namespace BasicDatabase_EF.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    // DI
    private readonly IApiRepository _repository;
    public ProductsController(IApiRepository repository)
    {
        _repository = repository;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _repository.GetProducts();

        return products.Any()
        ? Ok(products)
        : NoContent();
    }

    // GET by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _repository.GetProduct(id);

        return product != null
        ? Ok(product)
        : NotFound("Product not found!");
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        _repository.Add(product);

        return await _repository.SaveAllAsync()
        ? Ok("Product successfully added!")
        : BadRequest();
    }

    // PUT
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, Product product)
    {
        var productToUpdate = await _repository.GetProduct(id);
        if (productToUpdate == null)
            return NotFound("Product not found!");

        productToUpdate.ProductName = product.ProductName;
        productToUpdate.UnitPrice = product.UnitPrice;
        productToUpdate.IsDiscontinued = product.IsDiscontinued;

        return await _repository.SaveAllAsync()
        ? Ok("Product successfully updated!")
        : BadRequest();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var productToRemove = await _repository.GetProduct(id);

        if (productToRemove == null)
            return NotFound("Product not found!");

        _repository.Delete(productToRemove);

        return await _repository.SaveAllAsync()
        ? Ok("Product successfully deleted!")
        : BadRequest();
    }
}