using System;
using MongoDB.Bson.Serialization.Attributes;

namespace LandasBisnis_BackEnd.Models;

public class Admin : User
{
    [BsonElement("CanManageAdmins")]
    public bool CanManageAdmins {get; set;}
    [BsonElement("CanManageUsers")]
    public bool CanManageUsers {get; set;}
    [BsonElement("CanManageEvents")]
    public bool CanManageEvents {get; set;}
    [BsonElement("CanManageStatus")]
    public bool CanManageStatus {get; set;}
}
