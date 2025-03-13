using System;
using MongoDB.Bson.Serialization.Attributes;

namespace LandasBisnis_BackEnd.Models;

public class Sponsor : User
{
    [BsonElement("CompanyName")]
    public string CompanyName {get; set;} = null!;
    [BsonElement("CompanyAddress")]
    public string CompanyAddress {get; set;} = null!;
    [BsonElement("CompanyEmail")]
    public string CompanyEmail {get; set;} = null!;
    [BsonElement("PhoneNumber")]
    public string PhoneNumber {get; set;} = null!;
    [BsonElement("Role")]
    public string Role {get; set;} = "Sponsor";
}
