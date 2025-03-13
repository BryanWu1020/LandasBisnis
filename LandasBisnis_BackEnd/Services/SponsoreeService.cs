using System;
using AutoMapper;
using FluentValidation;
using LandasBisnis_BackEnd.Contracts;
using LandasBisnis_BackEnd.Models;
using LandasBisnis_BackEnd.Repositories;

namespace LandasBisnis_BackEnd.Services;

public interface ISponsoreeService{
    Task<List<Sponsoree>> Get(string? id);
    Task<Sponsoree?> Create(CreateSponsoreeContract sponsoree);
    Task<Sponsoree?> Update(UpdateSponsoreeContract sponsoree, string id);
    Task<Sponsoree?> Delete(string id);
}

public class SponsoreeService(IUserRepository<Sponsoree> repository, IMapper mapper, IValidator<CreateSponsoreeContract> createValidator) : ISponsoreeService{
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository<Sponsoree> _repository = repository;
    private readonly IValidator<CreateSponsoreeContract> _createValidator = createValidator;

    public async Task<List<Sponsoree>> Get(string? id){
        return await _repository.Get(id);
    }

    public async Task<Sponsoree?> Create(CreateSponsoreeContract sponsoree){
        _createValidator.ValidateAndThrow(sponsoree);
        var entity = _mapper.Map<Sponsoree>(sponsoree);
        entity.Password = BCrypt.Net.BCrypt.HashPassword(sponsoree.Password);
        return await _repository.Create(entity);
    }

    public async Task<Sponsoree?> Update(UpdateSponsoreeContract sponsoree, string id){
        var entity = _mapper.Map<Sponsoree>(sponsoree);
        return await _repository.Update(entity, id);
    }

    public async Task<Sponsoree?> Delete(string id){
        return await _repository.Delete(id);
    }
}
