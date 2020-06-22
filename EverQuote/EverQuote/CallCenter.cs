using EverQuote.Interfaces;
using System;
using System.Collections.Generic;

namespace EverQuote
{
    public class CallCenter : ICallCenter
    {
        private readonly List<IAgent> _agents;
        private readonly IRouter _router;
        private readonly Dictionary<Guid, Consumer> _consumers;

        public CallCenter(IRouter router, List<IAgent> agents)
        {
            _agents = agents;
            _router = router;
            _consumers = new Dictionary<Guid, Consumer>();
        }

        public void ReceiveCall(Consumer consumer)
        {
            if (!this._consumers.ContainsKey(consumer.Phone))
            {
                this._consumers.Add(consumer.Phone, consumer);
            }
            var selectedAgent = _router.SelectMatchingAgent(consumer, this._agents);
            _router.RedirectToAgent(consumer, selectedAgent);
        }

        public void AddAgent(IAgent agent)
        {
            this._agents.Add(agent);
        }

        public Consumer GetConsumer(Guid phoneNumber)
        {
            if (this._consumers.ContainsKey(phoneNumber))
            {
                return this._consumers[phoneNumber];
            }
            return null;
        }

    }
}