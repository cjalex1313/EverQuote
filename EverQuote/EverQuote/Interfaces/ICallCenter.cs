﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EverQuote.Interfaces
{
    public interface ICallCenter
    {
        public void ReceiveCall(Consumer consumer);
        public void AddAgent(IAgent anget);
        public Consumer GetConsumer(Guid phoneNumber);
    }
}
