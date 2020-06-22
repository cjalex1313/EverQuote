using EverQuote.Interfaces;
using System;

namespace EverQuote
{
    public class Consumer
    {
        private readonly int _age;
        private readonly string _state;
        private readonly int _kidsCount;
        private readonly int _carsCount;
        private readonly bool _rent;
        private readonly int _income;
        private readonly Guid _phone;

        public bool IsHandeled { get; set; }
        public Guid Phone { get
            {
                return _phone;
            } }

        public Consumer(int age, string state, int kidsCount, int carsCount, bool rent, int income, Guid phone)
        {
            this._age = age;
            this._state = state;
            this._kidsCount = kidsCount;
            this._carsCount = carsCount;
            this._rent = rent;
            this._income = income;
            this._phone = phone;
            this.IsHandeled = false;
        }

        public bool IsBusy()
        {
            throw new NotImplementedException();
        }

        public void Call(ICallCenter callCenter)
        {
            throw new NotImplementedException();
        }

        public bool ReceiveCall()
        {
            throw new NotImplementedException();
        }
    }
}