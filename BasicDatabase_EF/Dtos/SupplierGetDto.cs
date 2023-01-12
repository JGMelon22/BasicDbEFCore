namespace BasicDatabase_EF.Dots;

public class SupplierGetDto
{
    [Column("SupplierId")]
    public int SupplierId { get; set; }

    [Column("CompanyName")]
    public string CompanyName { get; set; } = string.Empty!;

    [Column("ContactName")]
    public string ContactName { get; set; } = string.Empty!;

    [Column("City")]
    public string City { get; set; } = string.Empty!;

    [Column("Country")]
    public string Country { get; set; } = string.Empty!;

    [Column("Phone")]
    public string Phone { get; set; } = string.Empty!;

    [Column("Fax")]
    public string? Fax { get; set; } // 12 chars with - and 10 with only numbers

    //
    [Column("ProductId")]
    public int ProductId { get; set; }

    [Column("ProductName")]
    public string ProductName { get; set; } = string.Empty!;

    [Column("UnitPrice")]
    public double UnitPrice { get; set; }

    [Column("Package")]
    public sbyte Package { get; set; } // package type: 1 - Cardboard, 2- Plastic, 3 - Foam

    [Column("IsDiscontinued")]
    public bool IsDiscontinued { get; set; }
}