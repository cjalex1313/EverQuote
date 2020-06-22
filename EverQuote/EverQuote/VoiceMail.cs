using System;
using System.Collections.Generic;

namespace EverQuote
{
    public class VoiceMail
    {
        private Queue<Consumer> _onHoldQueue;
        private readonly Queue<Consumer> _voiceMailQueue;

        public VoiceMail(Queue<Consumer> onHoldQueue)
        {
            _onHoldQueue = onHoldQueue;
            _voiceMailQueue = new Queue<Consumer>();
        }

        public Consumer GetNextVoiceMail()
        {
            throw new NotImplementedException();
        }

        public void Work()
        {
            throw new NotImplementedException();
        }

        public void MoveWaitingQueueToVoiceMail()
        {
            throw new NotImplementedException();
        }
    }
}