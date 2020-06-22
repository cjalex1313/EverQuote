using EverQuote.Interfaces;
using System;
using System.Collections.Generic;

namespace EverQuote
{
    public class CallCenter : ICallCenter
    {
        private readonly List<Agent> _agents;
        private readonly Router _router;
        private readonly Dictionary<Guid, Consumer> _consumers;

        public CallCenter()
        {
            _agents = new List<Agent>();
            _router = new Router();
            _consumers = new Dictionary<Guid, Consumer>();
        }

        public void ReceiveCall(Consumer consumer)
        {
            throw new NotImplementedException();
        }

        public void AddAgent(Agent anget)
        {
            throw new NotImplementedException();
        }

        public Consumer GetConsumer(Guid phoneNumber)
        {
            throw new NotImplementedException();
        }

    }
}