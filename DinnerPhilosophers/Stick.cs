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

        public void TakeStick(ref bool getLock)
        {
            Monitor.TryEnter(_locker, 2000, ref getLock);
        }

        public void PutStick()
        {
            Monitor.Exit(_locker);
        }
    }
}
