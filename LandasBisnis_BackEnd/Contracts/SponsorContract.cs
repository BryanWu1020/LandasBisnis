using System.Text.Json.Serialization;

namespace LandasBisnis_BackEnd.Contracts;

public record class SponsorContract : UserContract{
    [JsonPropertyName("companyName")]
    public string? CompanyName {get; set;}
    [JsonPropertyName("companyAddress")]
    public string? CompanyAddress {get; set;}
    [JsonPropertyName("companyEmail")]
    public string? CompanyEmail {get; set;}
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber {get; set;} = null!;
}

public record class UpdateSponsorContract : UpdateUserContract{
    [JsonPropertyName("companyName")]
    public string? CompanyName {get; set;}
    [JsonPropertyName("companyAddress")]
    public string? CompanyAddress {get; set;}
    [JsonPropertyName("companyEmail")]
    public string? CompanyEmail {get; set;}
    [JsonPropertyName("phoneNumber")]
    public string? PhoneNumber {get; set;} = null!;
}

public record class CreateSponsorContract : CreateUserContract{
    [JsonPropertyName("companyName")]
    public string CompanyName {get; set;} = null!;
    [JsonPropertyName("companyAddress")]
    public string CompanyAddress {get; set;} = null!;
    [JsonPropertyName("companyEmail")]
    public string CompanyEmail {get; set;} = null!;
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber {get; set;} = null!;
}