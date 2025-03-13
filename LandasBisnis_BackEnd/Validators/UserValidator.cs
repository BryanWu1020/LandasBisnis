using System;
using FluentValidation;
using LandasBisnis_BackEnd.Contracts;

namespace LandasBisnis_BackEnd.Validators;

public class CreateUserValidator<T> : AbstractValidator<T> where T : CreateUserContract{
    public CreateUserValidator(){
        RuleFor(x => x.Name).NotEmpty().MinimumLength(10).MaximumLength(20);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(10).MaximumLength(15).Matches("[A-Z]").Matches("[a-z]").Matches("[^a-zA-Z0-9]").Matches("[0-9]");
    }
}
