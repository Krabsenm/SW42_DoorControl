using System;
using System.Runtime.InteropServices;

namespace DoorControl
{
    public class DoorOpenedEventArgs : EventArgs { }

    public class DoorClosedEventArgs : EventArgs { }

    public interface IDoor
    {
        event EventHandler<DoorOpenedEventArgs> DoorOpenedEvent;

        event EventHandler<DoorClosedEventArgs> DoorClosedEvent;

        void Open();
        void Close();
    }
}