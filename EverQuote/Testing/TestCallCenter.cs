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
        public void TestReceiveCall()
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

        [Fact]
        public void TestGetConsumer()
        {
            //arrange
            Consumer consumer = new Consumer(16, "Ro", 0, 0, false, 0, Guid.NewGuid());
            var agents = new List<IAgent>();
            var router = new Mock<IRouter>();
            var callCenter = new CallCenter(router.Object, agents);
            //act
            callCenter.ReceiveCall(consumer);

            //assert
            Assert.Equal(consumer, callCenter.GetConsumer(consumer.Phone));
            Assert.Null(callCenter.GetConsumer(Guid.NewGuid()));
        }
    }
}
