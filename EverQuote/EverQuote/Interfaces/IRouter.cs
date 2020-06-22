using System;
using System.Collections.Generic;
using System.Text;

namespace EverQuote.Interfaces
{
    public interface IRouter
    {
        void RedirectToAgent(Consumer consumer, IAgent agent);
        IAgent SelectMatchingAgent(Consumer consumer, IEnumerable<IAgent> agents);
        IAgent SelectMostFreeAgent(IEnumerable<IAgent> agents);
    }
}
