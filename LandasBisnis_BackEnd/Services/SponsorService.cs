using System;
using AutoMapper;
using FluentValidation;
using LandasBisnis_BackEnd.Contracts;
using LandasBisnis_BackEnd.Models;
using LandasBisnis_BackEnd.Repositories;

namespace LandasBisnis_BackEnd.Services;

public interface ISponsorService{
    Task<List<Sponsor>> Get(string? id);
    Task<Sponsor?> Create(CreateSponsorContract sponsor);
    Task<Sponsor?> Update(UpdateSponsorContract sponsor, string id);
    Task<Sponsor?> Delete(string id);
}

public class SponsorService(IUserRepository<Sponsor> repository, IMapper mapper, IValidator<CreateSponsorContract> createValidator) : ISponsorService{
    private readonly IMapper _mapper = mapper;
    private readonly IUserRepository<Sponsor> _repository = repository;
    private readonly IValidator<CreateSponsorContract> _createValidator = createValidator;

    public async Task<List<Sponsor>> Get(string? id){
        return await _repository.Get(id);
    }

    public async Task<Sponsor?> Create(CreateSponsorContract sponsor){
        _createValidator.ValidateAndThrow(sponsor);
        var entity = _mapper.Map<Sponsor>(sponsor);
        return await _repository.Create(entity);
    }

    public async Task<Sponsor?> Update(UpdateSponsorContract sponsor, string id){
        var entity = _mapper.Map<Sponsor>(sponsor);
        return await _repository.Update(entity, id);
    }

    public async Task<Sponsor?> Delete(string id){
        return await _repository.Delete(id);
    }
}
