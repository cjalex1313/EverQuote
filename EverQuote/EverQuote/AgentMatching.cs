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
            if(this._ageInterval.Length != 2)
            {
                return false;
            }
            if(this._ageInterval[0] > this._ageInterval[1])
            {
                return false;
            }
            return (this._ageInterval[0] <= consumer.Age && this._ageInterval[1] >= consumer.Age);
        }
    }
}