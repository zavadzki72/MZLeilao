using Leilao.Domain.Core.Notifications;
using System.Threading.Tasks;
using CommandPackgage = Leilao.Domain.Core.Command;
using EventPackgage = Leilao.Domain.Core.Event;

namespace Leilao.Domain.Core.Bus {

    public interface IMediatorHandler {

        Task SendCommand<T>(T command) where T : CommandPackgage.Command;
        Task<TResponse> SendCommand<TRequest, TResponse>(TRequest command) where TRequest : CommandPackgage.Command<TResponse>;
        Task RaiseEvent<T>(T @event) where T : EventPackgage.Event;

    }

}
