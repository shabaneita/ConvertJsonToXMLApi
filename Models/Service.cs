namespace ConvertJsonToXMLApi.Models;

public class Service
{
    public string? MdgfClaimNumber { get; set; }
    public string? ServiceType { get; set; }
    public int? ServiceLineNo { get; set; }
    public string? ServiceCode { get; set; }
    public string? HCPCode { get; set; }
    public string? ServiceDescription { get; set; }
    public DateTime StartDate { get; set; } // Using DateTime for date fields
    public double? RQuantity { get; set; } // Using double type for decimal values
    public int? Duration { get; set; }
    public double? UnitPrice { get; set; } // Using double type for decimal values
    public double? PatientShareLC { get; set; } // Using double type for decimal values

}
