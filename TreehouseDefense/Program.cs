using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense
{
    class Program
    {
        public static void Main(string[] args)
        {
            Map map = new Map(8, 5);
            try
            {
                Path path = new Path(
                    new [] {
                        new MapLocation(0,2,map),
                        new MapLocation(1,2,map),
                        new MapLocation(2,2,map),
                        new MapLocation(3,2,map),
                        new MapLocation(4,2,map),
                        new MapLocation(5,2,map),
                        new MapLocation(6,2,map),
                        new MapLocation(7,2,map)
                    }
                );

                IInvader[] invaders =
                {
                    new ShieldedInvader(path),
                    new FastInvader(path),
                    new StrongInvader(path),
                    new BasicInvader(path),
                    new ResurrectingInvader(path)
                };
                Tower[] towers =
                {
                    new Tower(new MapLocation(1, 3, map)),
                    new SniperTower(new MapLocation(3, 3, map)),
                    //new LongRangeTower(new MapLocation(5, 3, map)),
                    //new PowerfulTower(new MapLocation(7, 3, map))
                };
                Level level = new Level(invaders)
                {
                    Towers = towers
                };
                bool playerWon = level.Play();
                Console.WriteLine("Player " + (playerWon? "won" : "lost"));
        
            }
            catch(OutOfBoundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (TreehouseDefenseException)
            {
                Console.WriteLine("Unhandled TreehouseDefenseException");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled Exception: " + ex);
            }

            Console.ReadLine();
        }
    }
}
