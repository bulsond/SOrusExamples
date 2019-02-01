using System;

namespace ConsoleApp1.Models
{
    public class FreezedWater : IVasyaState
    {
        //ничего не делаем
        public IVasyaState FreezeWater() => this;

        public IVasyaState WalkOnWater(Action addSteps)
        {
            addSteps();
            return this;
        }
    }
}
