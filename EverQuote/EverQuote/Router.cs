using EverQuote.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EverQuote
{
    public class Router : IRouter
    {
        public Router()
        {
        }

        public void RedirectToAgent(Consumer consumer, IAgent agent)
        {
            agent.ReceiveCall(consumer);
        }

        public IAgent SelectMatchingAgent(Consumer consumer, IEnumerable<IAgent> agents)
        {
            var matchingAgents = agents.Where(r => r.IsMatching(consumer)).ToList();
            if(matchingAgents == null || matchingAgents.Count == 0)
            {
                matchingAgents = agents.ToList();
            }
            var selected = this.SelectMostFreeAgent(matchingAgents);
            return selected;
        }

        public IAgent SelectMostFreeAgent(IEnumerable<IAgent> agents)
        {
            var result = agents.OrderBy(r => r.GetOnHoldCount()).FirstOrDefault();
            return result;
        }
    }
}