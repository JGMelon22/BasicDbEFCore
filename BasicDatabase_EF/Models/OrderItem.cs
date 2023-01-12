namespace BasicDatabase_EF.Models;

[Table("OrderItems")]
[Index(nameof(OrderItemId))]
public class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("OrderItemId")]
    public int OrderItemId { get; set; }

    [Column("UnitPrice")]
    [Required(ErrorMessage = "Unit Price is a required field!")]
    [Range(1, 999999.99)]
    public double UnitPrice { get; set; }

    // Navigation properties and FKs
    [ForeignKey("OrderId")]
    public int OrderId { get; set; }
    public Order Order { get; set; }

    [ForeignKey("ProductId")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

}