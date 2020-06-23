using EverQuote;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing
{
    public class AgentMatchingTest
    {
        [Fact]
        public void TestMatching()
        {
            //arrange
            Consumer consumer = new Consumer(16, "Ro", 0, 0, false, 0, Guid.NewGuid());
            var agentMatching1 = new AgentMatching(new int[] { 10, 20 }, "Ro", 0,0, false, new int[]{0,100});
            var agentMatching2 = new AgentMatching(new int[] { 20, 30 }, "Ro", 0,0, false, new int[] { 0, 100 });

            //act
            var result1 = agentMatching1.IsMatching(consumer);
            var result2 = agentMatching2.IsMatching(consumer);

            //assert
            Assert.True(result1);
            Assert.False(result2);
        }
    }
}
