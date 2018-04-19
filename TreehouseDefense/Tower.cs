using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense
{
    class Tower
    {
        protected virtual int Range { get; } = 1;
        protected virtual int Power { get; } = 1;
        protected virtual double Accuracy { get; } = .75;

        private readonly MapLocation _location;
        public Tower(MapLocation location)
        {
            _location = location;
        }
        public bool IsSuccessfulShot()
        {
            return Random.NextDouble() < Accuracy;
        }
        public void FireOnInvaders(IInvader[] invaders)
        {
            //int index = 0;
            ////While Loop
            //while (index < invaders.Length)
            //{
            //    Invader invader = invaders[index];
            //    //Do stuff with invader

            //    index++;               
            //}
            ////For Loop
            //for(int i = 0; i < invaders.Length; i++)
            //{
            //    Invader invader = invaders[i];
            //    //Do stuff with invader
            //}
            
            foreach(IInvader invader in invaders)
            {
                //Do stuff with invader
                if(invader.IsActive && _location.InRangeOf(invader.Location, Range))
                {
                    if (IsSuccessfulShot())
                    {
                        invader.DecreaseHealth(Power);
                        

                        if (invader.IsNeutralized)
                        {
                            Console.WriteLine("Neutralized an invader at " + invader.Location + "!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Shot at and missed an invader.");
                    }
                    break;
                }
            }
        }
    }
}
