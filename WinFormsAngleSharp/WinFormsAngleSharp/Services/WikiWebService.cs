using AngleSharp;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WinFormsAngleSharp.Models;

namespace WinFormsAngleSharp.Services
{
    class WikiWebService : IWebService
    {
        public async Task<WikiInfo> GetWikiPageAsync(string address)
        {
            //готовим результат
            var result = new WikiInfo();
            result.Header = "Не удалось загрузить данные по этому адресу.";

            //проверяем запрашиваемый адрес
            if (String.IsNullOrEmpty(address)) return result;

            //конфигурация для загрузки
            var config = Configuration.Default.WithDefaultLoader();

            try
            {
                //асинхронно загружаем страницу
                var document = await BrowsingContext.New(config).OpenAsync(address);

                //--Заголовок
                var cellSelector = @"h1#section_0";
                var cell = document.QuerySelector(cellSelector);
                result.Header = cell.TextContent;

                //--Параграфы
                cellSelector = @"main#content p";
                var cells = document.QuerySelectorAll(cellSelector);
                var pars = cells.Select(m => m.TextContent);
                result.Paragraphs.AddRange(pars);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка загрузки данных: {ex.Message}");
            }

            return result;
        }
    }
}
