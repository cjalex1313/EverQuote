using System;
using System.Collections.Generic;
using System.Threading;

namespace EverQuote
{
    public class VoiceMail
    {
        private Queue<Consumer> _onHoldQueue;
        private readonly Queue<Consumer> _voiceMailQueue;
        private Thread _thread = null;

        public int TotalVoiceMails { get; set; }

        public bool ShouldWork { get; set; } = true;

        public VoiceMail(Queue<Consumer> onHoldQueue)
        {
            _onHoldQueue = onHoldQueue;
            this.TotalVoiceMails = 0;
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

        public void StartWorking()
        {
            _thread = new Thread(() =>
            {
                this.Work();
            });
            _thread.Start();
        }
        
        public void StopWorking()
        {
            this.ShouldWork = false;
            if (_thread != null)
            {
                _thread.Join();
            }
        }

        private void Work()
        {
            while (ShouldWork)
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
                        this.TotalVoiceMails++;
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