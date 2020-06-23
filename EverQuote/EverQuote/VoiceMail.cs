﻿using System;
using System.Collections.Generic;
using System.Threading;

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

        public void AddToVoiceMail(Consumer consumer)
        {
            _voiceMailQueue.Enqueue(consumer);
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
            while (!App.IsDone)
            {
                Thread.Sleep(500);
                while(this._onHoldQueue.Count > 0)
                {
                    Consumer hangingConsumer = null;
                    lock (_onHoldQueue)
                    {
                        _onHoldQueue.TryDequeue(out hangingConsumer);
                    }
                    if (hangingConsumer == null)
                    {
                        continue;
                    }
                    else
                    {
                        _voiceMailQueue.Enqueue(hangingConsumer);
                    }
                }
            }
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