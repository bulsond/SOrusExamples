using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberNotationsUI.Models
{
    public class NotationService : INotationService
    {
        private List<INotation> _notations;

        //ctor
        public NotationService()
        {
            _notations = new List<INotation>
            {
                new DecimalNotation(),
                new BinaryNotation(),
                new HexNotation()
            };
        }

        public List<string> GetNotationsNames()
        {
            return _notations.Select(n => n.Name).ToList();
        }

        public string GetNotationValue(string inputNotation, string inputValue, string outputNotation)
        {
            //проверяем параметры
            if (string.IsNullOrEmpty(inputNotation))
                throw new ArgumentException(nameof(inputNotation));

            if (string.IsNullOrEmpty(inputValue))
                throw new ArgumentException(nameof(inputValue));

            if (string.IsNullOrEmpty(outputNotation))
                throw new ArgumentException(nameof(outputNotation));

            //ищем входную нотацию,
            INotation inputN = _notations.SingleOrDefault(n => n.Name.Equals(inputNotation));
            if (inputN == null) return String.Empty;

            //ищем выходную нотацию
            INotation outputN = _notations.SingleOrDefault(n => n.Name.Equals(outputNotation));
            if (outputN == null) return String.Empty;

            //пытаемся присвоить входной нотации значение
            if (inputN.SetValue(inputValue))
            {
                //передаем значение через int в выходную нотацию
                outputN.SetValue(inputN.ValueInt);
                //отдаем результат
                return outputN.ValueString;
            }
            //иначе возвращаем пустую строку
            return String.Empty;
        }
    }
}
