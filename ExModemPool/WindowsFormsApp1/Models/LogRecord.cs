using System;

namespace WindowsFormsApp1.Models
{
    /// <summary>
    /// Запись в лог приложения
    /// </summary>
    public class LogRecord
    {
        //ctor
        public LogRecord(int id, string message)
        {
            if (id <= 0) throw new ArgumentException(nameof(id));
            if (String.IsNullOrEmpty(message)) throw new ArgumentException(nameof(message));

            Id = id;
            Message = $"{Id}: {message}";
        }

        public int Id { get; private set; }
        public string Message { get; private set; }
    }
}
