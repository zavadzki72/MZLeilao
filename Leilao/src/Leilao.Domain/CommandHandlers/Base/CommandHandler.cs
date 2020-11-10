using Leilao.Domain.Core.Bus;
using Leilao.Domain.Core.Command;
using Leilao.Domain.Core.Notifications;

namespace Leilao.Domain.CommandHandlers.Base {

    public class CommandHandler {

        private readonly IMediatorHandler _bus;

        public CommandHandler(IMediatorHandler bus) {
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message) {
            foreach(var error in message.ValidationResult.Errors) {
                _bus.RaiseEvent(new DomainNotification(error.ErrorCode ?? message.MessageType, $"{message.MessageType} : {error.ErrorMessage}"));
            }
        }

        protected void NotifyValidationErrors<TResponse>(Command<TResponse> message) {
            foreach(var error in message.ValidationResult.Errors) {
                _bus.RaiseEvent(new DomainNotification(error.ErrorCode ?? message.MessageType, $"{message.MessageType} : {error.ErrorMessage}"));
            }
        }

    }
}
