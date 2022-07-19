using System;

namespace LSP
{
    public class Duck : Bird, IFlyable
    {
        public override void Scream() => Console.WriteLine("Quack!");

        public void Fly() => Console.WriteLine("Duck flies, quack-quack!");
    }
}
