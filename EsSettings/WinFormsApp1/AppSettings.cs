using System;

namespace WinFormsApp1
{
    class AppSettings
    {
        private const char _SEPARATOR_ = ';';
        private const string _BLANK_ = "-";

        public int Number { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Получение строки из значений свойств класса установок
        /// </summary>
        /// <param name="settings">экз.класса установок</param>
        /// <returns>результат в виде строки</returns>
        public static string GetSettingsLine(AppSettings settings)
        {
            if (String.IsNullOrEmpty(settings.Message))
            {
                settings.Message = _BLANK_;
            }
            return $"{settings.Number}{_SEPARATOR_}{settings.Message}{_SEPARATOR_}{settings.Date}";
        }

        /// <summary>
        /// Попытка разбора строки и получения экземпляра класса установок
        /// </summary>
        /// <param name="line">строка для разбора</param>
        /// <param name="settings">ссылка на выходной экз.класса установок</param>
        /// <returns>true если строка успешно разобрана</returns>
        public static bool TryParseSettingsLine(string line, out AppSettings settings)
        {
            settings = new AppSettings();
            //делим строку
            string[] sets = line.Split(new char[] { _SEPARATOR_ });
            //проверяем
            if (sets.Length != 3) return false;

            //пытаемся получить число
            if (Int32.TryParse(sets[0], out int num))
                settings.Number = num;
            else return false;

            //получаем сообщение
            if (sets[1] == _BLANK_)
                settings.Message = String.Empty;
            else
                settings.Message = sets[1];

            //пытаемся получить дату
            if (DateTime.TryParse(sets[2], out DateTime date))
                settings.Date = date;
            else return false;

            return true;
        }
    }
}
