using System;

namespace EverQuote
{
    public class Router
    {
        public Router()
        {
        }

        public void RedirectToAgent(Consumer consumer, Agent agent)
        {
            throw new NotImplementedException();
        }

        public Agent SelectMatchingAgent(Consumer consumer, IEquatable<Agent> agents)
        {
            throw new NotImplementedException();
        }

        public Agent SelectMostFreeAgent(IEquatable<Agent> agents)
        {
            throw new NotImplementedException();
        }
    }
}