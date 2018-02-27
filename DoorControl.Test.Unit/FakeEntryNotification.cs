using System;

namespace DoorControl
{
    class FakeEntryNotification : IEntryNotification
    {
        public void NotifyEntryGranted()
        {
            Console.WriteLine("Entry Granted");
        }

        public void NotifyEntryDenied()
        {
            Console.WriteLine("Entry Denied");
        }
    }
}