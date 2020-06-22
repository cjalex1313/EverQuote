using EverQuote;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing
{
    public class VoiceMailTest
    {
        [Fact]
        public void GetNextConsumerWhenQueueIsEmpty()
        {
            //arrange
            var queue = new Queue<Consumer>();
            var voiceMail = new VoiceMail(queue);
            //act
            var next = voiceMail.GetNextVoiceMail();

            //assert
            Assert.Null(next);
        }

        [Fact]
        public void GetNextCustomerWhenQueueNotEmpty()
        {
            //arrange
            var queue = new Queue<Consumer>();
            var voiceMail = new VoiceMail(queue);
            Consumer consumer = new Consumer(16, "Ro", 0, 0, false, 0, Guid.NewGuid());
            queue.Enqueue(consumer);
            voiceMail.MoveWaitingQueueToVoiceMail();

            //act
            var next = voiceMail.GetNextVoiceMail();

            //assert
            Assert.Equal(consumer, next);
        }
    }
}
