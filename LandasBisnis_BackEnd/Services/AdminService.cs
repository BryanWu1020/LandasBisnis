using System;
using AutoMapper;
using LandasBisnis_BackEnd.Contracts;
using LandasBisnis_BackEnd.Models;
using LandasBisnis_BackEnd.Repositories;

namespace LandasBisnis_BackEnd.Services;

public interface IAdminService{
    Task<List<Admin>> Get(string? id);
    Task<Admin?> Create(CreateAdminContract admin);
    Task<Admin?> Update(UpdateAdminContract admin, string id);
    Task<Admin?> Delete(string id);
}

public class AdminService(IUserRepository<Admin> repository, IMapper mapper) : IAdminService{
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository<Admin> _repository = repository;

    public async Task<List<Admin>> Get(string? id){
        return await _repository.Get(id);
    }

    public async Task<Admin?> Create(CreateAdminContract admin){
        admin.Password = BCrypt.Net.BCrypt.HashPassword(admin.Password);
        var entity = _mapper.Map<Admin>(admin);
        return await _repository.Create(entity);
    }

    public async Task<Admin?> Update(UpdateAdminContract admin, string id){
        var entity = _mapper.Map<Admin>(admin);
        return await _repository.Update(entity, id);
    }

    public async Task<Admin?> Delete(string id){
        return await _repository.Delete(id);
    }
}
