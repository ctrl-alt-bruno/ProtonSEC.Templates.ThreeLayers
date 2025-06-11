using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProtonSEC.Templates.ThreeLayers.Business.Interfaces;
using ProtonSEC.Templates.ThreeLayers.Business.Notifications;

namespace ProtonSEC.Templates.ThreeLayers.WebAPI.Controllers
{
	[ApiController]
	public abstract class MyControllerBase : ControllerBase
	{
		private readonly INotifier _notifier;

		public MyControllerBase(INotifier notifier)
		{
			_notifier = notifier;
		}

		protected bool IsValidOperation()
		{
			return _notifier.HasNotification();
		}

		protected void Notify(string message)
		{
			_notifier.Handle(new Notification(message));
		}

		protected void NotifyInvalidModelState(ModelStateDictionary modelStateDictionary)
		{
			IEnumerable<ModelError> errors = modelStateDictionary.Values.SelectMany(x => x.Errors);

			foreach (ModelError error in errors)
			{
				string errorMessage = error.Exception == null ?
					error.ErrorMessage :
					error.Exception.Message;

				Notify(errorMessage);
			}
		}

		protected ActionResult CustomResponse(HttpStatusCode httpStatusCode = HttpStatusCode.OK, object? result = null)
		{
			if (IsValidOperation())
				return new ObjectResult(result)
				{
					StatusCode = Convert.ToInt32(httpStatusCode)
				};

			return BadRequest(new
			{
				errors = _notifier.GetNotifications().Select(x => x.Message)
			});
		}

		protected ActionResult CustomResponse(ModelStateDictionary modelStateDictionary)
		{
			if (!modelStateDictionary.IsValid)
			{
				NotifyInvalidModelState(modelStateDictionary);
			}

			return CustomResponse();
		}
	}
}
