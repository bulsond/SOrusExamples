using System;

namespace WinFormsMySql.Utils
{
    /// <summary>
    /// Монада Result для возвращения результата вместо null
    /// и для случаев когда возникает Exception, а результат из метода
    /// нужно возвращать какой-то
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T>
    {
        public readonly T Value;
        public readonly string Error;

        //ctors
        public Result(T value)
        {
            Value = value;
            Error = String.Empty;
        }
        public Result(string error)
        {
            Error = error;
        }

        public bool HasValue => String.IsNullOrEmpty(Error);

        public static implicit operator bool(Result<T> result)
        {
            return result.HasValue;
        }
    }
}
