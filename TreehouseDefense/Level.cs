using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense
{
    class Level
    {
        private readonly IInvader[] _invaders;
        public Tower[] Towers { get; set; }
        public Level(IInvader[] invaders)
        {
            _invaders = invaders;
        }
        //Returns: true if the player wins, false otherwise.
        public bool Play()
        {
            //Run until all invaders are neutralized or invader reaches end of path.
            int remainingInvaders = _invaders.Length;
            while(remainingInvaders > 0)
            {
                //Each tower has opportunity to fire on invaders.
                foreach(Tower tower in Towers)
                {
                    tower.FireOnInvaders(_invaders);
                }
                //Count and move the invaders that are still active.
                remainingInvaders = 0;
                foreach(IInvader invader in _invaders)
                {
                    if (invader.IsActive)
                    {
                        invader.Move();
                        if (invader.HasScored)
                        {
                            return false;
                        }
                        remainingInvaders++;
                    }
                }

            }
            return true;

        }

    }
}
