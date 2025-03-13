using System;
using MongoDB.Bson.Serialization.Attributes;

namespace LandasBisnis_BackEnd.Models;

public class Sponsoree : User
{
    [BsonElement("OrganizationName")]
    public string OrganizationName {get; set;} = null!;
    [BsonElement("OrganizationAddress")]
    public string OrganizationAddress {get; set;} = null!;
    [BsonElement("OrganizationPhoneNumber")]
    public string OrganizationPhoneNumber {get; set;} = null!;
    [BsonElement("OrganizationEmail")]
    public string OrganizationEmail {get; set;} = null!;
    [BsonElement("PersonalPhoneNumber")]
    public string PersonalPhoneNumber {get; set;} = null!;
    [BsonElement("PersonalAddress")]
    public string PersonalAddress {get; set;} = null!;
    [BsonElement("Age")]
    public int Age {get; set;} 
}
