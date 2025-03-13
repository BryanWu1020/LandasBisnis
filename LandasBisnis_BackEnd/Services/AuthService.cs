using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using LandasBisnis_BackEnd.Models;
using LandasBisnis_BackEnd.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace LandasBisnis_BackEnd.Services;

public class AuthService(JwtSetting setting)
{
    private readonly JwtSetting _setting = setting;

    public string GenerateToken(User user){
        List<Claim> claims = [
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        ];
        if(user is Admin admin){
            claims.Add(new Claim("Role", "Admin"));
            foreach(var prop in admin.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)){
                if(prop.PropertyType == typeof(bool) && prop.GetValue(admin) is bool value && value){
                    claims.Add(new Claim(prop.Name, value.ToString()));
                }
            }
        }
        else if(user is Sponsor sponsor){
            claims.Add(new Claim("Role", "Sponsor"));
        }
        else if(user is Sponsoree sponsoree){
            claims.Add(new Claim("Role", "Sponsoree"));
        }
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(1),
            Issuer = _setting.Issuer,
            Audience = _setting.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_setting.Key)), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public void ConfigureJwtOptions(JwtBearerOptions options){
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters{
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_setting.Key)),
            ValidateIssuer = true,
            ValidIssuer = _setting.Issuer,
            ValidateAudience = true,
            ValidAudience = _setting.Audience,
            ValidateLifetime = true,
        };
    }
}
