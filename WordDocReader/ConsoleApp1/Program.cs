using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public static class WordCellExtensions
    {
        public static List<string> ParseXml(this Cell cell)
        {
            //извлекаем xml ячейки
            var xml = cell.Range.XML;

            XNamespace w = "http://schemas.microsoft.com/office/word/2003/wordml";
            XNamespace wx = "http://schemas.microsoft.com/office/word/2003/auxHint";
            XElement root = XElement.Parse(xml);

            //находим параграфы в ячейке
            var pars = root.Element(w + "body")
                           .Element(wx + "sect")
                           .Element(w + "tbl")
                           .Element(w + "tr")
                           .Element(w + "tc")
                           .Elements(w + "p");

            //проходим по параграфам и извлекаем данные
            XName listPrName = XName.Get("listPr", "http://schemas.microsoft.com/office/word/2003/wordml");
            List<string> result = new List<string>();
            foreach (var param in pars)
            {
                //текстовое содержимое параграфа
                var text = param.Element(w + "r").Element(w + "t").Value;

                //пытаемся найти ноду связанную с форматированием списка
                var listPr = param.Element(w + "pPr")
                                    .Elements()
                                    .FirstOrDefault(e => e.Name == listPrName);
                //если такой ноды нет
                //значит это не список
                if (listPr == null)
                {
                    result.Add(text);
                    continue;
                }

                //получаем символ связанный со строкой в списке
                var index = listPr.Element(wx + "t").Attribute(wx + "val").Value;
                result.Add($"{index} {text}");
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var pathToFile = Path.Combine(dir, "TableDoc.docx");

            Application word = new Application();
            object miss = System.Reflection.Missing.Value;
            object path = pathToFile;
            object readOnly = true;
            Document docs = word.Documents.Open(ref path, ref miss,
                ref readOnly, ref miss, ref miss, ref miss, ref miss,
                ref miss, ref miss, ref miss, ref miss, ref miss,
                ref miss, ref miss, ref miss, ref miss);

            //выбираем таблицу
            Table tb = docs.Tables[1];

            List<string> tableStrings = new List<string>();
            for (int row = 1; row <= tb.Rows.Count; row++)
            {
                for (int column = 1; column <= tb.Columns.Count; column++)
                {
                    var cell = tb.Cell(row, column);
                    //используем наш расш.метод для получения данных из ячейки
                    List<string> cellStrings = cell.ParseXml();
                    tableStrings.AddRange(cellStrings);
                }
            }

            docs.Close();
            word.Quit();

            //вывод прочитанных данных
            tableStrings.ForEach(s => Console.WriteLine(s));

            Console.ReadKey();
        }

    }
}
