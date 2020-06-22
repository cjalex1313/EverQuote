using EverQuote.Interfaces;
using System;
using System.Collections.Generic;

namespace EverQuote
{
    public class Router
    {
        public Router()
        {
        }

        public void RedirectToAgent(Consumer consumer, IAgent agent)
        {
            throw new NotImplementedException();
        }

        public Agent SelectMatchingAgent(Consumer consumer, IEnumerable<IAgent> agents)
        {
            throw new NotImplementedException();
        }

        public Agent SelectMostFreeAgent(IEnumerable<IAgent> agents)
        {
            throw new NotImplementedException();
        }
    }
}