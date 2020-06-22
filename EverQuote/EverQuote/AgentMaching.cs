using System;

namespace EverQuote
{
    public class AgentMaching
    {
        private readonly int[] _ageInterval;

        public AgentMaching(int[] ageInterval)
        {
            this._ageInterval = ageInterval;
        }

        public bool IsMatching(Consumer consumer)
        {
            throw new NotImplementedException();
        }
    }
}