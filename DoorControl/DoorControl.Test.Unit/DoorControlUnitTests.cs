using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DoorControl.Test.Unit
{
    public class DoorControlUnitTests
    {
        [Test]
        public void IsDoorOpen_testsState_ReturnsFalse()
        {
            var uut = new DoorControl();

          
            Assert.That(uut.IsDoorOpen(), Is.EqualTo(false));
        }
    }
}
