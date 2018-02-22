using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{
    public class DoorControl
    {
        private DoorStates currentState;

        public enum DoorStates
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

        public void DoorOpened()
        {
            if (currentState == DoorStates.DoorOpening)
            {
                _door.Close();

                currentState = DoorStates.DoorOpen;
            }
            else
            {
                _door.Close();

                _alarm.SignalAlarm();

                currentState = DoorStates.DoorBreached;
            }

        }

        public void DoorClosed()
        {
            if (currentState == DoorStates.DoorOpen)
                currentState = DoorStates.DoorClosed;
        }
    }
}
