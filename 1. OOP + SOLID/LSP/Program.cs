using System;

namespace LSP
{
    public class Program
    {
        public static void Main()
        {
            var flyingBirds = new IFlyable[]
            {
                new Duck(),
                new Colibri(),
            };

            FlyBirdsFly(flyingBirds);
        }

        public static void FlyBirdsFly(IFlyable[] birds)
        {
            foreach (var bird in birds)
            {
                bird.Fly();
            }
        }
    }
}
