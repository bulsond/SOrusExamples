using System;

namespace ConsoleApp1
{
    public abstract class ASoftware : ISoftware, IComparable<ISoftware>
    {
        //ctor
        public ASoftware(string name, string madeIn)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            if (string.IsNullOrEmpty(madeIn))
                throw new ArgumentException(nameof(madeIn));

            Name = name;
            MadeIn = madeIn;
        }

        public string Name { get; }
        public string MadeIn { get; }
        public virtual bool CanBeUsed => true;
        public string CanBeUsedString => CanBeUsed ? "Да" : "Нет";

        public int CompareTo(ISoftware other)
        {
            //все объекты не равные null рассматриваются большими 
            if (ReferenceEquals(other, null))
                return 1;

            //сравниваем по значению свойств
            int result = CompareValues(other);
            if (result == 0)
            {
                //тогда сравниваем по типам
                result = CompareTypes(other);
            }
            if (result == 0)
            {
                result = CanBeUsed.CompareTo(other.CanBeUsed);
            }

            return result;
        }

        //сравнение значений свойств
        protected virtual int CompareValues(ISoftware other)
        {
            //т.к. в конструкторе мы не даем создать экз. с null значениями св-в
            //то перед сравнением здесь нам не надо проверять на null
            //Сравниваем по двум свойствам
            int nameResult = Name.CompareTo(other.Name);
            int madeInResult = MadeIn.CompareTo(other.MadeIn);
            int result = nameResult + madeInResult;

            if (result < -1)
            {
                result = -1;
            }
            if (result > 1)
            {
                result = 1;
            }

            return result;
        }

        //сравнение типов
        protected int CompareTypes(object other)
        {
            int result = 0;

            Type thisType = this.GetType();
            Type otherType = other.GetType();

            if (otherType.IsSubclassOf(thisType))
            {
                //other - является производным классом
                result = 1;
            }
            if (thisType.IsSubclassOf(otherType))
            {
                //этот класс является производным от other
                result = -1;
            }

            return result;
        }

        //для полноценной реализации IComparable<T> мы еще должны
        //переопределить Equals() & GetHashCode()
        public override bool Equals(object obj)
        {
            return (CompareTo(obj as ISoftware) == 0);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ MadeIn.GetHashCode();
        }

        public override string ToString()
        {
            return $"Название продукта: {Name}" +
                $"\nСтрана производства: {MadeIn}";
        }

    }
}
