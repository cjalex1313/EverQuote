using EverQuote.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


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
                this._consumers.Add(newConsumer);
            }
        }

        public void GenerateAgents()
        {
            for(int i = 0; i < 20; i++)
            {
                var lower = i / 2 * 10 + 1;
                var higher = (i / 2 + 1) * 10;
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
            var threads = new List<Thread>();
            foreach(var agent in this._agents)
            {
                var thread = new Thread(() =>
                {
                    agent.Work();
                });
                threads.Add(thread);
                thread.Start();
            }
            var r = new Random();
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0;j<100; j++)
                {
                    var currentConsumer = this._consumers[(i * 100) + j];

                    this._callCenter.ReceiveCall(currentConsumer);
                    Thread.Sleep(r.Next(1, 10));
                }
            }
            while (!this._consumers.TrueForAll(r => r.IsHandeled))
            {
                Console.WriteLine("Customers to be handled = " + this._consumers.Where(r => r.IsHandeled == false).Count());
                Thread.Sleep(100);
            }
            App.IsDone = true;
            foreach(var thread in threads)
            {
                thread.Join();
            }
        }
    }
}
