using EverQuote;
using EverQuote.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing
{
    public class RouterTest
    {
        [Fact]
        public void TestSelectMatchingAgent()
        {
            //arrange
            Consumer consumer = new Consumer(16, "Ro", 0, 0, false, 0, Guid.NewGuid());
            var agent1 = new Mock<IAgent>();
            agent1.Setup(x => x.GetOnHoldCount()).Returns(2);
            agent1.Setup(x => x.IsMatching(consumer)).Returns(false);
            var agent2 = new Mock<IAgent>();
            agent2.Setup(x => x.GetOnHoldCount()).Returns(4);
            agent2.Setup(x => x.IsMatching(consumer)).Returns(true);
            var agent3 = new Mock<IAgent>();
            agent3.Setup(x => x.GetOnHoldCount()).Returns(6);
            agent3.Setup(x => x.IsMatching(consumer)).Returns(true);
            var router = new Router();
            //act
            var selected = router.SelectMatchingAgent(consumer, new List<IAgent>() { agent1.Object, agent2.Object, agent3.Object });

            //assert
            Assert.Equal(selected, agent2.Object);

        }

        [Fact]
        public void TestSelectMostFreeAgent()
        {
            //arrange
            var agent1 =  new Mock<IAgent>();
            agent1.Setup(x => x.GetOnHoldCount()).Returns(2);
            var agent2 = new Mock<IAgent>();
            agent2.Setup(x => x.GetOnHoldCount()).Returns(4);
            var router = new Router();

            //act
            var selected = router.SelectMostFreeAgent(new List<IAgent>() { agent1.Object, agent2.Object });

            //assert
            Assert.Equal(agent1.Object, selected);
        }

        [Fact]
        public void TestRedirectToAgent()
        {
            // arrange
            Consumer consumer = new Consumer(16, "Ro", 0, 0, false, 0, Guid.NewGuid());
            var router = new Router();
            var agent = new Mock<IAgent>();
            //act
            router.RedirectToAgent(consumer, agent.Object);

            //assert
            agent.Verify(x => x.ReceiveCall(consumer), Times.Exactly(1));
        }

    }
}
