using System;
using Leilao.Domain.Core.Models;
using MediatR;

namespace Leilao.Domain.Core.Event {

    public abstract class Event : Message, INotification {

        public DateTime Timestamp { get; }

        protected Event() {
            Timestamp = DateTime.Now;
        }
    }
}
