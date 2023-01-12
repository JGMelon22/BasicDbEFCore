namespace BasicDatabase_EF.Models;

[Table("Orders")]
[Index(nameof(OrderId))]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("OrderId")]
    public int OrderId { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    [Column("OrderDate")]
    [Required]
    public DateTime OrderDate { get; set; }

    [Column("TotalAmount")]
    [Required(ErrorMessage = "Total Amount is a required field!")]
    [Range(1, 999999.99)]
    public double TotalAmount { get; set; }

    // Navigation properties and FKs
    [ForeignKey("CustomerId")]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; }
}