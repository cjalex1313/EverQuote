using System;
using System.Collections.Generic;
using System.Text;

namespace EverQuote.Interfaces
{
    public interface IAgent
    {
        void SetCallCenter(CallCenter center);
        void ReceiveCall(Consumer consumer);
        void CallConsumer(Consumer consumer);
        void CheckVoiceMail();
        int GetVoiceMailSize();
        bool IsMatching(Consumer consumer);
        void Answer(Consumer consumer);
        void Work();
    }
}
