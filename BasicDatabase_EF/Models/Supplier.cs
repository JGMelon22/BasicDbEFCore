namespace BasicDatabase_EF.Models;

[Table("Suppliers")]
[Index(nameof(SupplierId))]
public class Supplier
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("SupplierId")]
    public int SupplierId { get; set; }

    [Column("CompanyName")]
    [Required(ErrorMessage = "Company Name is a required field!")]
    [MaxLength(100)]
    public string CompanyName { get; set; } = string.Empty!;

    [Column("ContactName")]
    [Required(ErrorMessage = "Contact Name is a required field!")]
    [MaxLength(100)]
    public string ContactName { get; set; } = string.Empty!;

    [Column("City")]
    [Required(ErrorMessage = "City is a required field!")]
    [MaxLength(50)]
    public string City { get; set; } = string.Empty!;

    [Column("Country")]
    [Required(ErrorMessage = "Country is a required field!")]
    [MaxLength(50)]
    public string Country { get; set; } = string.Empty!;

    [Column("Phone")]
    [Required(ErrorMessage = "Phone is a required field!")]
    [Phone]
    public string Phone { get; set; } = string.Empty!;

    [Column("Fax")]
    [MaxLength(12, ErrorMessage = "Fax can't exceed 12 characters!")]
    public string? Fax { get; set; } // 12 chars with - and 10 with only numbers

    // Navigation property
    public Product Product { get; set; }
}