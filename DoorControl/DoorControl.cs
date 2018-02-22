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
            DoorOpen
        }

        private IDoor _door;
        private IUserValidation _userValidation;
        private IEntryNotification _entryNotification;

        public DoorControl(IDoor door, IUserValidation userValidation, IEntryNotification entryNotification, DoorStates currentState)
        {
            _door = door;
            _userValidation = userValidation;
            _entryNotification = entryNotification;
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



        }

        public void DoorOpened()
        {
            if (currentState == DoorStates.DoorOpening)
            {
                _door.Close();

                currentState = DoorStates.DoorOpen;
            }

        }

        public void DoorClosed()
        {
            if (currentState == DoorStates.DoorOpen)
                currentState = DoorStates.DoorClosed;
        }
    }
}
