using System;
using FluentValidation;
using LandasBisnis_BackEnd.Contracts;

namespace LandasBisnis_BackEnd.Validators;

public class CreateSponsorValidator : CreateUserValidator<CreateSponsorContract>{
    public CreateSponsorValidator(){
        RuleFor(x => x.CompanyAddress).NotEmpty();
        RuleFor(x => x.CompanyName).NotEmpty();
        RuleFor(x => x.CompanyEmail).NotEmpty().EmailAddress();
        RuleFor(x => x.PhoneNumber).NotEmpty().Matches("^[0-9]+$");
    }
}
