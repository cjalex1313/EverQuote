using EverQuote;
using EverQuote.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing
{
    public class TestCallCenter
    {

        [Fact]
        public void CallCenter_Consumer_Is_Registered_After_Calling()
        {
            //arrange
            var agents = new List<IAgent>();
            var router = new Mock<IRouter>();
            var callCenter = new CallCenter(router.Object, agents);
            Consumer consumer = new Consumer(16, "Ro", 0, 0, false, 0, Guid.NewGuid());
            //act
            callCenter.ReceiveCall(consumer);

            //assert
            router.Verify(x => x.SelectMatchingAgent(consumer, agents), Times.Exactly(1));
            Assert.Equal(callCenter.GetConsumer(consumer.Phone), consumer);
        }
    }
}
