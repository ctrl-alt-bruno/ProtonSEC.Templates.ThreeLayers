using FluentValidation;
using FluentValidation.Results;
using ProtonSEC.Templates.ThreeLayers.Business.Interfaces;
using ProtonSEC.Templates.ThreeLayers.Business.Models;
using ProtonSEC.Templates.ThreeLayers.Business.Notifications;

namespace ProtonSEC.Templates.ThreeLayers.Business.Services
{
    public abstract class BaseService(INotifier notifier)
    {
        protected bool Validate<TValidation, TEntity>(TValidation validation, TEntity? entity)
            where TValidation : AbstractValidator<TEntity>
            where TEntity : Entity
        {
            if (entity == null)
                return false;

            ValidationResult validationResult = validation.Validate(entity);

            if (validationResult.IsValid)
                return true;

            Notify(validationResult);

            return false;
        }

        private void Notify(ValidationResult validationResult)
        {
            foreach (ValidationFailure? error in validationResult.Errors)
                Notify(error.ErrorMessage);
        }

        protected void Notify(string message)
        {
            notifier.Handle(new Notification(message));
        }
    }
}