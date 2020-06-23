using EverQuote.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EverQuote
{
    public class App
    {
        private readonly CallCenter _callCenter;
        private readonly List<Consumer> _consumers;
        private readonly List<IAgent> _agents;
        public static bool IsDone = false;

        public App()
        {
            _agents = new List<IAgent>();
            var router = new Router();
            _callCenter = new CallCenter(router, _agents);
            _consumers = new List<Consumer>();
            
        }

        public void GenerateConsumers()
        {
            var r = new Random();
            for(int i = 0; i< 1000; i++)
            {
                var newConsumer = new Consumer(r.Next(1, 100), "Ro", r.Next(5), r.Next(5), false, r.Next(1200, 20000), Guid.NewGuid());
            }
        }

        public void GenerateAgents()
        {
            for(int i = 0; i < 20; i++)
            {
                var lower = i * 5 + 1;
                var higher = (i + 1) * 5;
                var agenMatching = new AgentMatching(new int[] { lower, higher });
                var agent = new Agent(agenMatching);
                _agents.Add(agent);
            }
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
