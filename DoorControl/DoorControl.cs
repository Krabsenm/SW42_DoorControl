using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorControl
{
    public class DoorControl
    {
        private bool _isDoorOpen;

        public DoorControl()
        {
            _isDoorOpen = false;
        }

        public bool IsDoorOpen()
        {

            return _isDoorOpen; 
        }
    }
}
