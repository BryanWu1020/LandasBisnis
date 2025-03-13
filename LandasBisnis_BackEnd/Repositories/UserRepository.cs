using System;
using LandasBisnis_BackEnd.Models;
using LandasBisnis_BackEnd.Settings;
using MongoDB.Driver;

namespace LandasBisnis_BackEnd.Repositories;

public interface IUserRepository<T> where T : User{
    Task<List<T>> Get(string? id = null, string? email = null);
    Task<T?> Create(T entity);
    Task<T?> Update(T entity, string id);
    Task<T?> Delete(string id);
}

public class UserRepository<T>(DatabaseSetting setting) : IUserRepository<T> where T : User{
    private readonly IMongoCollection<T> _collection = new MongoClient(setting.ConnectionString).GetDatabase(setting.DatabaseName).GetCollection<T>("users");

    public async Task<List<T>> Get(string? id = null, string? email = null){
        var filterBuilder = Builders<T>.Filter;
        var filter = filterBuilder.Empty;
        filter &= filterBuilder.AnyIn("_t", typeof(T).Name);
        if (id != null) filter &= filterBuilder.Eq(p => p.Id, id);
        if(email != null) filter &= filterBuilder.Eq(p => p.Email, email);
        return await _collection.Find(filter).ToListAsync();
    }

    public async Task<T?> Create(T entity){
        await _collection.InsertOneAsync(entity);
        return entity;
    }

    public async Task<T?> Update(T entity, string id){
        T target = await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        if(target == null) return null;
        return await _collection.FindOneAndReplaceAsync(p => p.Id == id, entity);
    }

    public async Task<T?> Delete(string id){
        T target = await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        if(target == null) return null;
        return await _collection.FindOneAndDeleteAsync(p => p.Id == id);
    }
}
