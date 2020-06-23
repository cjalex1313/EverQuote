using EverQuote;
using EverQuote.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing
{
    public class ConsumerTest
    {
        [Fact]
        public void Consumer_Is_Not_Handled_By_Default()
        {
            //arrange
            Consumer consumer = new Consumer(16, "Ro", 0, 0, false, 0, Guid.NewGuid());
            //act

            //assert
            Assert.False(consumer.IsHandeled);
        }

        [Fact]
        public void Consumer_Is_Setting_IsHandled_To_True_After_Answering()
        {
            //arrange
            Consumer consumer = new Consumer(16, "Ro", 0, 0, false, 0, Guid.NewGuid());

            //act
            while (!consumer.IsHandeled)
            {
                consumer.ReceiveCall();
            }

            //assert
            Assert.True(consumer.IsHandeled);
        }

        [Fact]
        public void Consumer_Registers_In_Call_Center_After_Calling()
        {
            //arrange
            Consumer consumer = new Consumer(16, "Ro", 0, 0, false, 0, Guid.NewGuid());
            var mockCenter = new Mock<ICallCenter>();
            mockCenter.Setup(x => x.GetConsumer(consumer.Phone)).Returns(consumer);

            //act
            consumer.Call(mockCenter.Object);

            //assert
            var consumerInCenter = mockCenter.Object.GetConsumer(consumer.Phone);
            Assert.Equal(consumerInCenter, consumer);
            mockCenter.Verify(x => x.GetConsumer(consumer.Phone), Times.Exactly(1));
        }
    }
}
