using System;
using System.Threading.Tasks;
using AutoMapper;
using LandasBisnis_BackEnd.Contracts;
using LandasBisnis_BackEnd.Models;
using LandasBisnis_BackEnd.Repositories;
using Microsoft.AspNetCore.Identity.Data;

namespace LandasBisnis_BackEnd.Services;

public interface IUserService{
    Task<LoginResponse?> Login(Credential credential);
    Task<List<UserContract>> Get();
}

public class UserService(IUserRepository<User> repository, AuthService auth, IMapper mapper) : IUserService
{
    private readonly IUserRepository<User> _repository = repository;
    private readonly AuthService _auth = auth;
    private readonly IMapper _mapper = mapper;

    public async Task<List<UserContract>> Get(){
        var user = await _repository.Get();
        return _mapper.Map<List<UserContract>>(user);
    }
    public async Task<LoginResponse?> Login(Credential credential){
        var user = (await _repository.Get(null, credential.Email))[0];
        if(user != null && BCrypt.Net.BCrypt.Verify(credential.Password, user.Password)){
            return new LoginResponse{
                User = _mapper.Map<UserContract>(user),
                Token = _auth.GenerateToken(user) 
            };
        }
        return null;
    }
}
