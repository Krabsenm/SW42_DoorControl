using System;

namespace DoorControl
{
    class Alarm : IAlarm
    {
        public void SignalAlarm()
        {
            Console.WriteLine("Door Breached *BWEEP bip bip BWEEP*");
        }
    }
}