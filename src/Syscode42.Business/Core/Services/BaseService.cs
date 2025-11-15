using FluentValidation;
using FluentValidation.Results;
using Syscode42.Business.Core.Models;
using Syscode42.Business.Core.Notifications;

namespace Syscode42.Business.Core.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;

        protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
		}

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
			}
        }

		protected void Notify(string message)
		{
			_notifier.Handle(new Notification(message));
		}

		protected bool ExecuteValidation<TValidation, TEntity>(TValidation validation, TEntity entity)
            where TValidation : AbstractValidator<TEntity> where TEntity : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) 
                return true;

            Notify(validator);
			return false;
        }
    }
}
