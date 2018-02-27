using System.Collections.Generic;

namespace DoorControl
{
    class UserValidation : IUserValidation
    {
        private List<string> _validUserId; 

        public UserValidation()
        {
            _validUserId.Add("abc");
        }

        public bool ValidateEntryRequest(string id)
        {
            return _validUserId.Contains(id);
        }
    }
}