using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ThreeLayerArch.Business.Interfaces;
using ThreeLayerArch.Business.Notifications;

namespace ThreeLayerArch.API.Controllers
{
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly INotifier _notifier;

        protected MainController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool ValidOperation()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK,
            object result = null)
        {
            if (ValidOperation())
            {
                return new ObjectResult(result)
                {
                    StatusCode = Convert.ToInt32(statusCode),
                };
            }

            return BadRequest(new
            {
                errors = _notifier.GetAllNotifications().Select(n => n.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifierErroModelInvalid(modelState);
            return CustomResponse();
        }

        protected void NotifierErroModelInvalid(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var err in errors)
            {
                var errMsg = err.Exception == null ? err.ErrorMessage : err.Exception.Message;
                NoficationError(errMsg);
            }
        }

        protected void NoficationError(string message)
        {
            _notifier.Handler(new Notification(message));
        }
	}
}

