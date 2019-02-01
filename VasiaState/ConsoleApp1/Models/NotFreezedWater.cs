using System;

namespace ConsoleApp1.Models
{
    public class NotFreezedWater : IVasyaState
    {
        //меняем состояние на заморож.воду
        public IVasyaState FreezeWater() => new FreezedWater();

        //шаги не прибавляем, просто возвращаем текущее сост.
        public IVasyaState WalkOnWater(Action addSteps) => this;
    }
}
