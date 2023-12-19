using FluentValidation;
using FluentValidation.Results;
using ThreeLayerArch.Business.Interfaces;
using ThreeLayerArch.Business.Models;
using ThreeLayerArch.Business.Notifications;

namespace ThreeLayerArch.Business.Services
{
	public class BaseService
	{
		private readonly INotifier _notifier;

		public BaseService(INotifier notifier)
		{
			_notifier = notifier;
		}

		protected bool ExecuteValidation<TValidation, TEntity>(TValidation validation, TEntity entity)
			where TValidation : AbstractValidator<TEntity>
			where TEntity : Entity
		{
			var validator = validation.Validate(entity);

			if (validator.IsValid) return true;

            Notify(validator);

			return false;
		}

		protected void Notify(ValidationResult validationResult)
		{
			foreach (var item in validationResult.Errors)
			{
				Notify(item.ErrorMessage);
			}
		}

		protected void Notify(string message)
		{
			_notifier.Handler(new Notification(message));
		}
	}
}

