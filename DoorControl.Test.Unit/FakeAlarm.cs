using System;

namespace DoorControl
{
    class FakeAlarm : IAlarm
    {
        public void SignalAlarm()
        {
            Console.WriteLine("Door Breached *BWEEP bip bip BWEEP*");
        }
    }
}