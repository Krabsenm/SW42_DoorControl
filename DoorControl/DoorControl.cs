namespace DoorControl
{
    public class DoorControl
    {
        private DoorStates _currentState;

        private enum DoorStates
        {
            DoorClosed,
            DoorOpening,
            DoorOpen,
            DoorBreached
        }

        private readonly IDoor _door;
        private readonly IUserValidation _userValidation;
        private readonly IEntryNotification _entryNotification;
        private readonly IAlarm _alarm;

        public DoorControl(IDoor door, IUserValidation userValidation, IEntryNotification entryNotification, IAlarm alarm)
        {
            _door = door;
            _userValidation = userValidation;
            _entryNotification = entryNotification;
            _alarm = alarm;
            _currentState = DoorStates.DoorClosed;

            if (_door == null) return;
            _door.DoorOpenedEvent += HandleDoorOpenedEvent;
            _door.DoorClosedEvent += HandleDoorClosedEvent;
        }


        public void RequestEntry(string id)
        {
            if (_currentState != DoorStates.DoorClosed) return;

            if (_userValidation.ValidateEntryRequest(id))
            {
                _door.Open();

                _entryNotification.NotifyEntryGranted();

                _currentState = DoorStates.DoorOpening;
            }
            else
            {
                _entryNotification.NotifyEntryDenied();
            }
        }


        public void HandleDoorOpenedEvent(object source, DoorOpenedEventArgs args)
        {
            switch (_currentState)
            {
                case DoorStates.DoorOpening:
                    _door.Close();
                    _currentState = DoorStates.DoorOpen;
                    break;

                case DoorStates.DoorClosed:
                    _door.Close();
                    _alarm.SignalAlarm();
                    _currentState = DoorStates.DoorBreached;
                    break;
            }
        }

        public void HandleDoorClosedEvent(object source, DoorClosedEventArgs args)
        {
            switch (_currentState)
            {
                case DoorStates.DoorOpen:
                    _currentState = DoorStates.DoorClosed;
                    break;
            }
        }

        public bool IsKrillinat0rABailer()
        {
            return true;
        }
    }
}
