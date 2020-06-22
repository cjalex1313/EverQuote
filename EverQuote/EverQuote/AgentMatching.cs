using System;

namespace EverQuote
{
    public class AgentMatching
    {
        private readonly int[] _ageInterval;

        public AgentMatching(int[] ageInterval)
        {
            this._ageInterval = ageInterval;
        }

        public bool IsMatching(Consumer consumer)
        {
            throw new NotImplementedException();
        }
    }
}