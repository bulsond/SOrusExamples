using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Services
{
    class DownloadService
    {

        /// <summary>
        /// Загрузка файла с сайта
        /// </summary>
        /// <param name="downloadUrl">путь к загружаемому</param>
        /// <param name="pathToSave">путь к сохраняемому</param>
        /// <param name="progress">объект отображения процесса загрузки</param>
        /// <param name="token">токен отмены загрузки</param>
        /// <returns></returns>
        public static async Task DownloadAsync(string downloadUrl, string pathToSave, IProgress<int> progress, CancellationToken token)
        {
            if (downloadUrl == null)
                throw new ArgumentNullException(nameof(downloadUrl));

            if (pathToSave == null)
                throw new ArgumentNullException(nameof(pathToSave));

            if (progress == null)
                throw new ArgumentNullException(nameof(progress));

            //клиент
            HttpClient client = new HttpClient();

            using (HttpResponseMessage response = await client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead))
            {
                //проверяем успешность запроса
                response.EnsureSuccessStatusCode();

                //получаем размер скачиваемого файла
                string header = response.Content.Headers.First(h => h.Key.Equals("Content-Length")).Value.First();
                long size = Int64.Parse(header);

                using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                using (FileStream fileStream = new FileStream(pathToSave, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {
                    decimal totalRead = 0; //всего закачено 
                    int totalReads = 0; //всего буферов скачано
                    byte[] buffer = new byte[8192];
                    bool isMoreToRead = true;

                    do
                    {
                        //скачиваем в буфер
                        int read = await contentStream.ReadAsync(buffer, 0, buffer.Length);
                        if (read == 0)
                        {
                            isMoreToRead = false;
                        }
                        else
                        {
                            //запись данных в файл
                            await fileStream.WriteAsync(buffer, 0, read);

                            totalRead += read;
                            totalReads += 1;

                            //вывод промежуточного результата
                            if (totalReads % 100 == 0)
                            {
                                int percent = Convert.ToInt32(totalRead / size * 100);
                                progress.Report(percent);
                            }
                        }

                        //не пришел ли запрос на отмену закачки
                        if (token.IsCancellationRequested)
                        {
                            isMoreToRead = false;
                        }
                    }
                    while (isMoreToRead);
                }//using
            }//using

        }//Method

    }//class
}
