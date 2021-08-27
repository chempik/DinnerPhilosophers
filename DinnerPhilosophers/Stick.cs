using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DinnerPhilosophers
{
    public class Stick
    {
        private object _locker = new object();
        private TimeSpan _time = new TimeSpan (4000);

        public bool TakeStick()
        {
            if (Monitor.TryEnter(_locker, _time)) return true;

            else return false;
        }

        public void PutStick()
        {
            Monitor.Exit(_locker);
        }
    }
}
