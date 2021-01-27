using Entities.Concrete;
using FluentValidation;

namespace ConnectionBusiness.ValidationRules.FluentValidation
{
    public class ClienttValidator:AbstractValidator<Client>
    {
        public ClienttValidator()
        {
            RuleFor(p => p.Ip).NotEmpty().WithErrorCode("2020").NotNull().WithErrorCode("2020"); ;
        }
    }
}
