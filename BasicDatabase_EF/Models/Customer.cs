namespace BasicDatabase_EF.Models;

[Table("Customers")]
[Index(nameof(CustomerId))]
public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("CustomerId")]
    public int CustomerId { get; set; }

    [Column("FirstName")]
    [Required(ErrorMessage = "Customer First Name is a required field")]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty!;

    [Column("LastName")]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty!;

    [Column("City")]
    [Required(ErrorMessage = "City is a required field!")]
    [MaxLength(50)]
    public string City { get; set; } = string.Empty!;

    [Column("Country")]
    [Required(ErrorMessage = "Country is a required field!")]
    [MaxLength(50)]
    public string Country { get; set; } = string.Empty!;

    [Column("Phone")]
    [Phone]
    [Required(ErrorMessage = "Phone is a required field!")]
    public string Phone { get; set; } = string.Empty!;

    // Navigation properties
    public ICollection<Order> Orders { get; set; }

}