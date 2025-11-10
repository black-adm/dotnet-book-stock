using FluentValidation;

namespace Syscode42.Business.Models.Products.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("The {PropertyName} must be provided.")
                .Length(2, 200)
                .WithMessage("The {PropertyName} must be between {MinLength} and {MaxLength} characters.");
        
            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("The {PropertyName} must be provided.")
                .Length(2, 1000)
                .WithMessage("The {PropertyName} must be between {MinLength} and {MaxLength} characters.");

            RuleFor(p => p.Value)
                .GreaterThan(0)
                .WithMessage("The {PropertyName} must be greater than {ComparisonValue}.");
        }
    }
}
