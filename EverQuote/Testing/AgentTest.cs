using EverQuote;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing
{
    public class AgentTest
    {
        [Fact]
        public void TestReceiveCall()
        {
            //arrange
            Consumer consumer = new Consumer(16, "Ro", 0, 0, false, 0, Guid.NewGuid());
            var agent = new Agent(new AgentMatching(new int[] { 10, 20 }));
            //act
            agent.ReceiveCall(consumer);

            //assert
            Assert.Equal(agent.OnHoldQueue.Count, 1);
        }

        [Fact]
        public void TestCallConsumer()
        {
            //arrage
            Consumer consumer = new Consumer(16, "Ro", 0, 0, false, 0, Guid.NewGuid());
            var agent = new Agent(new AgentMatching(new int[] { 10, 20 }));
            agent.ReceiveCall(consumer);
            //act
            while (!consumer.IsHandeled)
            {
                agent.CallConsumer(consumer);
            }
            //assert
            Assert.True(consumer.IsHandeled);
        }
    }
}
