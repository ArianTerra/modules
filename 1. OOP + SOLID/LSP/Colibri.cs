using System;

namespace LSP
{
    public class Colibri : Bird, IFlyable
    {
        public override void Scream() => Console.WriteLine("eeeeee");

        public void Fly() => Console.WriteLine("Colibri flies very fast");
    }
}
