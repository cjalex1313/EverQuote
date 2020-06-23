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
        int GetOnHoldCount();
        bool IsMatching(Consumer consumer);
        void Answer(Consumer consumer);
        void Work();
        void Stop();
        string ToReportLine();
        int TotalVoiceMails { get; }
    }
}
