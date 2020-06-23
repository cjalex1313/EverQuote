using System;

namespace EverQuote
{
    public class AgentMatching
    {
        private readonly int[] _ageInterval;
        private readonly string _state;
        private readonly int _kids;
        private readonly int _car;
        private readonly bool _rent;
        private readonly int[] _incomeInterval;

        public int[] AgeInterval { get { return _ageInterval; } }
        public string State { get { return _state; } }
        public int Kids { get { return _kids; } }
        public int Cars { get { return _car; } }
        public bool Rent { get { return _rent; } }
        public int[] Income { get { return _incomeInterval; } }

        public AgentMatching(int[] ageInterval, string state, int kids, int car, bool rent, int[] incomeInterval )
        {
            this._ageInterval = ageInterval;
            this._state = state;
            this._kids = kids;
            this._car = car;
            this._rent = rent;
            this._incomeInterval = incomeInterval;
              
        }

        public bool IsMatching(Consumer consumer)
        {
            bool ok = true;
            if(this._ageInterval.Length != 2)
            {
                ok = false;
            }
            if(this._ageInterval[0] > this._ageInterval[1])
            {
                ok = false;
            }
            if(!(this._ageInterval[0] <= consumer.Age && this._ageInterval[1] >= consumer.Age))
            {
                ok = false;
            }
            if(this._state != consumer.State)
            {
                ok = false;
            }
            if(this._kids != consumer.Kids)
            {
                ok = false;
            }
            if (this._car != consumer.Cars)
            {
                ok = false;
            }
            if(this._rent != consumer.Rent)
            {
                ok = false;
            }
            if (this._incomeInterval.Length != 2)
            {
                ok = false;
            }
            if (this._incomeInterval[0] > this._incomeInterval[1])
            {
                ok = false;
            }
            if (!(this._incomeInterval[0] <= consumer.Income && this._incomeInterval[1] >= consumer.Income))
            {
                ok = false;
            }
            return ok;
        }
    }
}