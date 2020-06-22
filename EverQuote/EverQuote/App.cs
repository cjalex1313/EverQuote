using System;
using System.Collections.Generic;
using System.Text;

namespace EverQuote
{
    public class App
    {
        private readonly CallCenter _callCenter;

        public App()
        {
            _callCenter = new CallCenter();
        }

        public void GenerateConsumers()
        {
            throw new NotImplementedException();
        }

        public void GenerateAgents()
        {
            throw new NotImplementedException();
        }

        public void SubmitReport()
        {
            throw new NotImplementedException();
        }

        public void StartSimulation()
        {
            throw new NotSupportedException();
        }
    }
}
