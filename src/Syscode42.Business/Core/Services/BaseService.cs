using FluentValidation;
using Syscode42.Business.Core.Models;

namespace Syscode42.Business.Core.Services
{
    public abstract class BaseService
    {
        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity)
            where TV: AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);
            return validator.IsValid;
        }
    }
}
