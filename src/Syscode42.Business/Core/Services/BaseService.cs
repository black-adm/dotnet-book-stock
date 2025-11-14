using FluentValidation;
using Syscode42.Business.Core.Models;

namespace Syscode42.Business.Core.Services
{
    public abstract class BaseService
    {
        protected bool ExecuteValidation<TValidation, TEntity>(TValidation validation, TEntity entity)
            where TValidation : AbstractValidator<TEntity> where TEntity : Entity
        {
            var validator = validation.Validate(entity);
            return validator.IsValid;
        }
    }
}
