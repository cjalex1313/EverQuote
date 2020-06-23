using System;
using System.Threading;
using EverQuote;

namespace EverQuote
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new EverQuote.App();
            app.GenerateConsumers();
            app.GenerateAgents();
            app.StartSimulation();
        }
    }
}
