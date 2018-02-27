using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{
    public class DoorControl
    {
        private DoorControl.DoorStates currentState;

        private enum DoorStates
        {
            DoorClosed,
            DoorOpening,
            DoorOpen,
            DoorBreached
        }

        private IDoor _door;
        private IUserValidation _userValidation;
        private IEntryNotification _entryNotification;
        private IAlarm _alarm;

        public DoorControl(IDoor door, IUserValidation userValidation, IEntryNotification entryNotification, IAlarm alarm)
        {
            _door = door;
            _userValidation = userValidation;
            _entryNotification = entryNotification;
            _alarm = alarm;
            currentState = DoorStates.DoorClosed;

            _door.DoorOpenedEvent += HandleDoorOpenedEvent;
            _door.DoorClosedEvent += HandleDoorClosedEvent;
        }


        public void RequestEntry(string id)
        {
            if (_userValidation.ValidateEntryRequest(id))
            {
                _door.Open();

                _entryNotification.NotifyEntryGranted();

                currentState = DoorStates.DoorOpening;
            }
            else
            {
                _entryNotification.NotifyEntryDenied();
            }
        }


        public void HandleDoorOpenedEvent(object source, DoorOpenedEventArgs args)
        {
            switch (currentState)
            {
                case DoorStates.DoorOpening:
                    _door.Close();
                    currentState = DoorStates.DoorOpen;
                    break;

                case DoorStates.DoorClosed:
                    _door.Close();
                    _alarm.SignalAlarm();
                    currentState = DoorStates.DoorBreached;
                    break;
            }
        }

        public void HandleDoorClosedEvent(object source, DoorClosedEventArgs args)
        {
            switch (currentState)
            {
                case DoorStates.DoorOpen:
                    currentState = DoorStates.DoorClosed;
                    break;
            }
        }
    }
}
