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
                bool rightStick = false;
                bool leftStick = false;
                Left.TakeStick(ref leftStick);
                Right.TakeStick(ref rightStick);

                if (rightStick && leftStick)
                {
                    ++Ate;
                    Console.WriteLine($"{Name} eat {Ate} time");
                    //a highly respected philosopher needs time to eat
                    Thread.Sleep(2000);
                }
                if (leftStick) Left.PutStick();
                if (rightStick) Right.PutStick();

                //a highly respected philosopher needs time to think
                Thread.Sleep(2000);
            }
        }
    }
}
