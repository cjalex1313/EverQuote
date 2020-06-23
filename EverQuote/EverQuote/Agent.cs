using EverQuote.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EverQuote
{
    public class Agent : IAgent
    {
        private readonly AgentMatching _agentMaching;
        private readonly Queue<Consumer> _onHoldQueue;
        private readonly VoiceMail _voiceMail;
        private CallCenter _callCenter;

        public IEnumerable<Guid> AnsweredCalls { get; set; }
        public Dictionary<Guid, int> SentCalls { get; set; }

        public Queue<Consumer> OnHoldQueue { get
            {
                return _onHoldQueue;
            } }

        public Agent(AgentMatching agentMaching)
        {
            Console.WriteLine("Agent Created");
            this._agentMaching = agentMaching;
            this._onHoldQueue = new Queue<Consumer>();
            this._voiceMail = new VoiceMail(_onHoldQueue);
            var voiceThread = new Thread(() =>
            {
                this._voiceMail.Work();
            });
            voiceThread.Start();
            this.AnsweredCalls = new List<Guid>();
            this.SentCalls = new Dictionary<Guid, int>();
        }

        public void SetCallCenter(CallCenter center)
        {
            this._callCenter = center;
        }

        public void ReceiveCall(Consumer consumer)
        {
            this._onHoldQueue.Enqueue(consumer);
        }

        public void CallConsumer(Consumer consumer)
        {
            consumer.IsHandeled = !consumer.IsBusy();
            if (!consumer.IsHandeled)
            {
                this._voiceMail.AddToVoiceMail(consumer);
            }
            else
            {
                Random r = new Random();
                int wait = r.Next(50, 300); //for ints
                Thread.Sleep(wait);
            }
        }

        public void CheckVoiceMail()
        {
            var voiceMailConsumer = _voiceMail.GetNextVoiceMail();
            if(voiceMailConsumer != null)
            {
                this.CallConsumer(voiceMailConsumer);
            }
        }

        public bool IsMatching(Consumer consumer)
        {
            return this._agentMaching.IsMatching(consumer);
        }

        public void Answer(Consumer consumer)
        {
            Random r = new Random();
            int wait = r.Next(50, 300); //for ints
            Thread.Sleep(wait);
            consumer.IsHandeled = true;
        }

        public void Work()
        {
            while (!App.IsDone)
            {
                
                while(_onHoldQueue.Count > 0)
                {
                    Consumer next = null;
                    lock (_onHoldQueue)
                    {
                        _onHoldQueue.TryDequeue(out next);
                    }
                    if(next == null)
                    {
                        continue;
                    }
                    this.Answer(next);
                }

                Consumer nextVoiceMail = _voiceMail.GetNextVoiceMail();
                while(nextVoiceMail != null)
                {
                    this.CallConsumer(nextVoiceMail);
                    nextVoiceMail = _voiceMail.GetNextVoiceMail();
                }
            }
        }

        public int GetOnHoldCount()
        {
            lock (this._onHoldQueue)
            {
                return this._onHoldQueue.Count;
            }
        }
    }
}