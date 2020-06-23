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
        public void VoiceMail_Next_VoiceMail_Is_Null_When_Queue_Is_Empty()
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
        public void VoiceMail_Next_VoiceMail_Is_Consumer_When_Queue_Is_Not_Empty()
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
