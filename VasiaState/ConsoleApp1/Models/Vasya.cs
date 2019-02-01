namespace ConsoleApp1.Models
{
    public class Vasya
    {
        //ctor
        public Vasya()
        {
            CountSteps = 0;
            State = new NotFreezedWater();
        }

        //состояние Васи
        public IVasyaState State { get; set; }

        //количество проделанных шагов
        public int CountSteps { get; private set; }

        public void FreezeWater()
        {
            State = State.FreezeWater();
        }

        public void WalkOnWater(int steps)
        {
            State = State.WalkOnWater(() => { this.CountSteps += steps; });
        }
    }
}
