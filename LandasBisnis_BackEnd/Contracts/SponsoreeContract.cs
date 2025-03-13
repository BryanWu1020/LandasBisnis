using System.Text.Json.Serialization;

namespace LandasBisnis_BackEnd.Contracts;

public record class SponsoreeContract : UserContract{
    [JsonPropertyName("organizationName")]
    public string OrganizationName {get; set;} = null!;
    [JsonPropertyName("organizationAddress")]
    public string OrganizationAddress {get; set;} = null!;
    [JsonPropertyName("organizationPhoneNumber")]
    public string OrganizationPhoneNumber {get; set;} = null!;
    [JsonPropertyName("organizationEmail")]
    public string OrganizationEmail {get; set;} = null!;
    [JsonPropertyName("personalPhoneNumber")]
    public string PersonalPhoneNumber {get; set;} = null!;
    [JsonPropertyName("personalAddress")]
    public string PersonalAddress {get; set;} = null!;
    [JsonPropertyName("age")]
    public int Age {get; set;} 
}

public record class UpdateSponsoreeContract : UpdateUserContract{
    [JsonPropertyName("organizationName")]
    public string? OrganizationName {get; set;}
    [JsonPropertyName("organizationAddress")]
    public string? OrganizationAddress {get; set;}
    [JsonPropertyName("organizationPhoneNumber")]
    public string? OrganizationPhoneNumber {get; set;}
    [JsonPropertyName("organizationEmail")]
    public string? OrganizationEmail {get; set;}
    [JsonPropertyName("personalPhoneNumber")]
    public string? PersonalPhoneNumber {get; set;}
    [JsonPropertyName("personalAddress")]
    public string? PersonalAddress {get; set;}
    [JsonPropertyName("age")]
    public int? Age {get; set;} 
}

public record class CreateSponsoreeContract : CreateUserContract{
    [JsonPropertyName("organizationName")]
    public string OrganizationName {get; set;} = null!;
    [JsonPropertyName("organizationAddress")]
    public string OrganizationAddress {get; set;} = null!;
    [JsonPropertyName("organizationPhoneNumber")]
    public string OrganizationPhoneNumber {get; set;} = null!;
    [JsonPropertyName("organizationEmail")]
    public string OrganizationEmail {get; set;} = null!;
    [JsonPropertyName("personalPhoneNumber")]
    public string PersonalPhoneNumber {get; set;} = null!;
    [JsonPropertyName("personalAddress")]
    public string PersonalAddress {get; set;} = null!;
    [JsonPropertyName("age")]
    public int Age {get; set;} 
}
