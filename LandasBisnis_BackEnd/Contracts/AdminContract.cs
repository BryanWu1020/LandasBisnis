using System.Text.Json.Serialization;

namespace LandasBisnis_BackEnd.Contracts;

public record class AdminContract : UserContract{
    [JsonPropertyName("canManageAdmins")]
    public bool CanManageAdmins {get; set;}
    [JsonPropertyName("canManageUsers")]
    public bool CanManageUsers {get; set;}
    [JsonPropertyName("canManageEvents")]
    public bool CanManageEvents {get; set;}
    [JsonPropertyName("canManageStatus")]
    public bool CanManageStatus {get; set;}
}

public record class UpdateAdminContract : UpdateUserContract{
    [JsonPropertyName("canManageAdmins")]
    public bool? CanManageAdmins {get; set;}
    [JsonPropertyName("canManageUsers")]
    public bool? CanManageUsers {get; set;}
    [JsonPropertyName("canManageEvents")]
    public bool? CanManageEvents {get; set;}
    [JsonPropertyName("canManageStatus")]
    public bool? CanManageStatus {get; set;}
}

public record class CreateAdminContract : CreateUserContract{
    [JsonPropertyName("canManageAdmins")]
    public bool CanManageAdmins {get; set;}
    [JsonPropertyName("canManageUsers")]
    public bool CanManageUsers {get; set;}
    [JsonPropertyName("canManageEvents")]
    public bool CanManageEvents {get; set;}
    [JsonPropertyName("canManageStatus")]
    public bool CanManageStatus {get; set;}
}
