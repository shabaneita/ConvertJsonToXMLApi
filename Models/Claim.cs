namespace ConvertJsonToXMLApi.Models;

public class Claim
{
    public string? MdgfClaimNumber { get; set; }
    public string? HCPID { get; set; }
    public string? InsuredID { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public DateTime OccurenceDate { get; set; }
    public string? PrimaryDiagnosis { get; set; }
    public string? SecondaryICDs { get; set; }
    public string? PolicyNo { get; set; }
    public string? PractionerId { get; set; }
    public string? SpecialityCode { get; set; }
    public string? ClaimBenefit { get; set; }
    public double? LengthOfStay { get; set; }
    public string? DischargeDiagnosisCode { get; set; }
    public string? DischargeOtherDiag { get; set; }
}
public enum GenderType
{
    Male,
    Female
}
