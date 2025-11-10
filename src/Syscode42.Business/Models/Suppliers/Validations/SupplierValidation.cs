using FluentValidation;
using Syscode42.Business.Core.Validations.Documents;

namespace Syscode42.Business.Models.Suppliers.Validations
{
    public class SupplierValidation : AbstractValidator<Supplier>
    {
        public SupplierValidation()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("The field {PropertyName} needs to be provided")
                .Length(2, 200)
                .WithMessage("The field {PropertyName} needs to have between {MinLength} and {MaxLength} characters");

            When(s => s.SupplierType == SupplierType.PF, () =>
            {
                RuleFor(s => s.Document.Length)
                    .Equal(CPFValidation.CPF_LENGTH)
                    .WithMessage("The field {PropertyName} needs to have {ComparisonValue} characters");
            
                RuleFor(s => CPFValidation.IsValid(s.Document))
                    .Equal(true)
                    .WithMessage("The document {PropertyValue} is invalid");
            });

            When(s => s.SupplierType == SupplierType.PJ, () =>
            {
                RuleFor(s => s.Document.Length)
                    .Equal(CNPJValidation.CNPJ_LENGTH)
                    .WithMessage("The field {PropertyName} needs to have {ComparisonValue} characters");
            
                RuleFor(s => CNPJValidation.IsValid(s.Document))
                    .Equal(true)
                    .WithMessage("The document {PropertyValue} is invalid");
            });
        }
    }
}
