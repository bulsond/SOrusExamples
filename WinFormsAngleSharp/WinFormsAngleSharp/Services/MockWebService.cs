using System;
using System.Threading.Tasks;
using WinFormsAngleSharp.Models;

namespace WinFormsAngleSharp.Services
{
    class MockWebService : IWebService
    {
        public Task<WikiInfo> GetWikiPageAsync(string address)
        {
            //готовим результат
            var result = new WikiInfo();
            result.Header = "Не удалось загрузить данные по этому адресу.";

            //проверяем запрашиваемый адрес
            if(String.IsNullOrEmpty(address)) return Task.FromResult(result);

            //тестовый результат
            result.Header = "Тестовые данные";
            result.Paragraphs.Add("Тестовый параграф 1");
            result.Paragraphs.Add("Тестовый параграф 2");
            result.Paragraphs.Add("Тестовый параграф 3");

            //отдаем тестовый результат
            return Task.FromResult(result);
        }
    }
}
