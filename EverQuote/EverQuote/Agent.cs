using EverQuote.Interfaces;
using System;
using System.Collections.Generic;

namespace EverQuote
{
    public class Agent : IAgent
    {
        private readonly AgentMaching _agentMaching;
        private readonly Queue<Consumer> _onHoldQueue;
        private readonly VoiceMail _voiceMail;
        private CallCenter _callCenter;

        public IEnumerable<Guid> AnsweredCalls { get; set; }
        public Dictionary<Guid, int> SentCalls { get; set; }

        public Agent(AgentMaching agentMaching)
        {
            this._agentMaching = agentMaching;
            this._onHoldQueue = new Queue<Consumer>();
            this._voiceMail = new VoiceMail(_onHoldQueue);
            this.AnsweredCalls = new List<Guid>();
            this.SentCalls = new Dictionary<Guid, int>();
        }

        public void SetCallCenter(CallCenter center)
        {
            throw new NotImplementedException();
        }

        public void ReceiveCall(Consumer consumer)
        {
            throw new NotImplementedException();
        }

        public void CallConsumer(Consumer consumer)
        {
            throw new NotImplementedException();
        }

        public void CheckVoiceMail()
        {
            throw new NotImplementedException();
        }

        public int GetVoiceMailSize()
        {
            throw new NotImplementedException();
        }

        public bool IsMatching(Consumer consumer)
        {
            throw new NotImplementedException();
        }

        public void Answer(Consumer consumer)
        {
            throw new NotImplementedException();
        }

        public void Work()
        {
            throw new NotImplementedException();
        }
    }
}