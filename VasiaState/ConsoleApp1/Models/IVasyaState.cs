using System;

namespace ConsoleApp1.Models
{
    public interface IVasyaState
    {
        IVasyaState FreezeWater();
        IVasyaState WalkOnWater(Action addSteps);
    }
}