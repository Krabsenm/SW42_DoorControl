using System;

namespace DoorControl
{
    public class FakeDoor : IDoor
    {
        public event EventHandler<DoorOpenedEventArgs> DoorOpenedEvent;
        public event EventHandler<DoorClosedEventArgs> DoorClosedEvent;

        public void Open()
        {       
        }

        public void Close()
        {
        }
    }
}