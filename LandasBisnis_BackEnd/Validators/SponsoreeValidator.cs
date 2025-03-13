using System;
using FluentValidation;
using LandasBisnis_BackEnd.Contracts;

namespace LandasBisnis_BackEnd.Validators;

public class CreateSponsoreeValidator : CreateUserValidator<CreateSponsoreeContract>{
    public CreateSponsoreeValidator(){
        RuleFor(x => x.OrganizationName).NotEmpty();
        RuleFor(x => x.OrganizationAddress).NotEmpty();
        RuleFor(x => x.OrganizationEmail).NotEmpty().EmailAddress();
        RuleFor(x => x.OrganizationPhoneNumber).NotEmpty().Matches("^[0-9]+$");
        RuleFor(x => x.PersonalAddress).NotEmpty();
        RuleFor(x => x.PersonalPhoneNumber).NotEmpty().Matches("^[0-9]+$");
        RuleFor(x => x.Age).NotEmpty().GreaterThan(17);
    }
}
