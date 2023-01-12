namespace BasicDatabase_EF.Models;

[Table("Products")]
[Index(nameof(ProductId))]
public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ProductId")]
    public int ProductId { get; set; }

    [Column("ProductName")]
    [Required(ErrorMessage = "Product Name is a required field!")]
    [MaxLength(100)]
    public string ProductName { get; set; } = string.Empty!;

    [Column("UnitPrice")]
    [Required(ErrorMessage = "Unit Price is a required field!")]
    [Range(1, 999999.99)]
    public double UnitPrice { get; set; }

    [Column("Package")]
    [Required(ErrorMessage = "Package is a required field!")]
    [Range(1, 3, ErrorMessage = "Package type must be between 1 and 3")]
    public sbyte Package { get; set; } // package type: 1 - Cardboard, 2- Plastic, 3 - Foam

    [Column("IsDiscontinued")]
    [Required(ErrorMessage = "Is Discontinued is a required field!")]
    public bool IsDiscontinued { get; set; }

    // Navigation properties and FKs
    [ForeignKey("SupplierId")]
    public int SupplierId { get; set; }

    public Supplier Supplier { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
}