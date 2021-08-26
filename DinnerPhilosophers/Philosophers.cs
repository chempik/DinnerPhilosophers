using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DinnerPhilosophers
{
    public class Philosophers
    {
        public string Name;
        public Stick Left;
        public Stick Right;
        public int Ate = 0;
        
        public void Eatting(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var takeLeftStick = Left.TakeStick();
                var takeRightStick = Right.TakeStick();
                if (takeLeftStick && takeRightStick)
                {
                    ++Ate;
                    Console.WriteLine($"{Name} eat {Ate} time");
                    //a highly respected philosopher needs time to eat
                    Thread.Sleep(2000);
                }
                if (takeLeftStick) Left.PutStick();
                if (takeRightStick) Right.PutStick();

                //a highly respected philosopher needs time to think
                Thread.Sleep(2000);
            }
        }
    }
}
