using EverQuote.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
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
        public List<string> States = new List<string>() { "RO", "US" };

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
                var newConsumer = new Consumer(r.Next(1, 100), this.States[r.Next(0,2)], r.Next(5), r.Next(5), false, r.Next(1200, 20000), Guid.NewGuid());
                this._consumers.Add(newConsumer);
            }
        }

        public void GenerateAgents()
        {
            var r = new Random();
            for(int i = 0; i < 20; i++)
            {
                var lower = i / 2 * 10 + 1;
                var higher = (i / 2 + 1) * 10;
                var lowerIncome = r.Next(1200, 15000);
                var highIncome = r.Next(lowerIncome, 20000);
                var agenMatching = new AgentMatching(new int[] { lower, higher }, this.States[r.Next(0, 2)], r.Next(0,6), r.Next(0, 6), r.Next(0,2) == 0, new int[] { lowerIncome, highIncome } );
                var agent = new Agent(agenMatching);
                _agents.Add(agent);
            }
        }

        public void SubmitReport()
        {
            GenerateConsumersCSV();
            GenerateAgentsCSV();
            GenerateConsumerTotalTimesCalled();
            GenerateAgentTotalVoiceMails();
        }

        private void GenerateAgentTotalVoiceMails()
        {
            var builder = new StringBuilder();
            builder.AppendLine("AgentNumber,TotalVoiceMails,TotalCallsAnswered");
            int i = 1;
            foreach (var agent in _agents)
            {
                builder.AppendLine($"{i},{agent.TotalVoiceMails},{agent.CallsReceived}");
            }
            var filePath = "agentsTotalVoiceMails.csv";
            File.WriteAllText(filePath, builder.ToString());
        }

        private void GenerateConsumerTotalTimesCalled()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Phone,TotalTime");
            foreach (var consumer in _consumers)
            {
                builder.AppendLine($"{consumer.Phone},{consumer.TotalTimesCalled}");
            }
            var filePath = "consumersCalled.csv";
            File.WriteAllText(filePath, builder.ToString());
        }

        private void GenerateAgentsCSV()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Age,Kids,Cars,Income,State");
            foreach (var agent in _agents)
            {
                builder.AppendLine($"{agent.ToReportLine()}");
            }
            var filePath = "agents.csv";
            File.WriteAllText(filePath, builder.ToString());
        }

        private void GenerateConsumersCSV()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Phone,Age,Kids,Cars,Income,State");
            foreach (var consumer in _consumers)
            {
                builder.AppendLine($"{consumer.Phone},{consumer.Age},{consumer.Kids},{consumer.Cars},{consumer.Income},{consumer.State}");
            }
            var filePath = "consumers.csv";
            File.WriteAllText(filePath, builder.ToString());
        }

        public void StartSimulation()
        {
            foreach(var agent in this._agents)
            {
                agent.StartWorking();
            }
            var r = new Random();
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 100; j++)
                {
                    var currentConsumer = this._consumers[(i * 100) + j];

                    this._callCenter.ReceiveCall(currentConsumer);
                    Thread.Sleep(r.Next(1, 10));
                }
            }
            while (!this._consumers.TrueForAll(r => r.IsHandeled))
            {
                Console.WriteLine("Customers to be handled = " + this._consumers.Where(r => r.IsHandeled == false).Count());
                Thread.Sleep(1000);
            }
            foreach (var agent in _agents)
            {
                agent.StopWorking();
            }
        }
    }
}
