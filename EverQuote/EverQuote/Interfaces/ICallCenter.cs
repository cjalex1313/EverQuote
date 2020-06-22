using System;
using System.Collections.Generic;
using System.Text;

namespace EverQuote.Interfaces
{
    public interface ICallCenter
    {
        public void ReeciveCall(Consumer consumer);
        public void AddAgent(Agent anget);
        public Consumer GetConsumer(Guid phoneNumber);
    }
}
