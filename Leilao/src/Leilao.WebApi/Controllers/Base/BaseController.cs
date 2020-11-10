using Leilao.Domain.Core.Bus;
using Leilao.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace Leilao.WebApi.Controllers.Base {

    public class BaseController : ControllerBase {

        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        protected BaseController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation() {
            return (!_notifications.HasNotifications());
        }

        protected new ActionResult Response() {

            if(IsValidOperation())
                return Ok(new { success = true });

            return BadRequest(new {
                success = false,
                errors = _notifications.GetNotifications().Select(n => new { n.Code, n.Message })
            });

        }

        protected new ActionResult Response<T>(T result) {

            if(IsValidOperation()) {

                if(result == null) {
                    return NotFound(new {
                        success = false,
                        data = "Object not found"
                    });
                } else {
                    return Ok(new {
                        success = true,
                        data = result
                    });
                }
            }

            return BadRequest(new {
                success = false,
                errors = _notifications.GetNotifications().Select(n => new { n.Code, n.Message })
            });
        }

        protected void NotifyError(string code, string message) {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }
    }
}
