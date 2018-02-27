using System.Collections.Generic;

namespace DoorControl
{
    class FakeUserValidation : IUserValidation
    {
        private List<string> _validUserId; 

        public FakeUserValidation()
        {
            _validUserId.Add("abc");
        }

        public bool ValidateEntryRequest(string id)
        {
            return _validUserId.Contains(id);
        }
    }
}