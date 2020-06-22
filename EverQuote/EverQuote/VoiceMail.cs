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
            if(_voiceMailQueue.Count > 0)
            {
                return _voiceMailQueue.Dequeue();
            }
            return null;
        }

        public void Work()
        {
            throw new NotImplementedException();
        }

        public void MoveWaitingQueueToVoiceMail()
        {
            while(_onHoldQueue.Count > 0)
            {
                _voiceMailQueue.Enqueue(_onHoldQueue.Dequeue());
            }
        }
    }
}