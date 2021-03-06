﻿using EverQuote.Interfaces;
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

        public int Age { get
            {
                return _age;
            } }

        public string State { get
            {
                return _state;
            } }

        public int Kids { get
            {
                return _kidsCount;
            } }

        public int Cars
        {
            get
            {
                return _carsCount;
            }
        }

        public bool Rent
        {
            get
            {
                return _rent;
            }
        }

        public int Income
        {
            get
            {
                return _income;
            }
        }

        public int TotalTimesCalled { get; set; }


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
            this.TotalTimesCalled = 0;
        }

        public bool IsBusy()
        {
            Random gen = new Random();
            int prob = gen.Next(100);
            return prob <= 80;
        }

        public void Call(ICallCenter callCenter)
        {
            callCenter.ReceiveCall(this);
        }

        public bool ReceiveCall()
        {
            this.IsHandeled = this.IsBusy();
            return this.IsHandeled;
        }
    }
}