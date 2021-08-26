using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DinnerPhilosophers
{
    public class Stick
    {
        private Mutex _mute = new Mutex(); 

        public bool TakeStick()
        {
            if (_mute.WaitOne(3000)) return true;
            else return false;
        }

        public void PutStick()
        {
            _mute.ReleaseMutex();
        }
    }
}
