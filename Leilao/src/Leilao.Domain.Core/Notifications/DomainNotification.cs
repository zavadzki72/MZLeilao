using EventPackgage = Leilao.Domain.Core.Event;

namespace Leilao.Domain.Core.Notifications {

    public class DomainNotification : EventPackgage.Event {

        public DomainNotification(string code, string message) {
            Code = code;
            Message = message;
        }

        public string Code { get; }

        public string Message { get; }
    }
}
