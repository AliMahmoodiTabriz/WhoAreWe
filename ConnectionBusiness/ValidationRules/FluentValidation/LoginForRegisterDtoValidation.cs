using Entities.Dtos;
using FluentValidation;

namespace ConnectionBusiness.ValidationRules.FluentValidation
{
    public class LoginForRegisterDtoValidation : AbstractValidator<UserForLoginDto>
    {
        public LoginForRegisterDtoValidation()
        {
            RuleFor(p => p.Email).NotEmpty().WithErrorCode("2030").NotNull().WithErrorCode("2031");
            RuleFor(p => p.Password).NotEmpty().WithErrorCode("2032").NotNull().WithErrorCode("2033");
            RuleFor(p => p.Email).EmailAddress().WithErrorCode("2034");
        }
    }
}
