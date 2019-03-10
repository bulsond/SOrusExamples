using System;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SoftwareCollection softwares = new SoftwareCollection
            {
                new FreeSoftware("FileZilla", "США"),
                new ProprietarySoftware("Adobe Photoshop", "США",
                        DateTime.Parse("12.12.2018"), TimeSpan.FromDays(360), 3600),
                new SharewareSoftware("WinRar", "Россия",
                        DateTime.Parse("12.12.2018"), TimeSpan.FromDays(90)),
                new ProprietarySoftware("ABBYY FineReader", "Россия",
                        DateTime.Parse("06.06.2017"), TimeSpan.FromDays(360), 2800),
                new FreeSoftware("FireFox Mozilla", "США")
            };

            //
            Console.WriteLine("=====До сортировки======");
            PrintCollection(softwares);
            Console.WriteLine("========================");

            Console.WriteLine("Для продолжения нажмите Ввод...");
            Console.ReadLine();

            softwares.Sort();

            Console.WriteLine("=====После сортировки======");
            PrintCollection(softwares);
            Console.WriteLine("========================");

            Console.WriteLine("Для продолжения нажмите Ввод...");
            Console.ReadLine();


            var freeSoftwares = softwares.GetSoftwareByType<FreeSoftware>(typeof(FreeSoftware));
            Console.WriteLine("=====Только Free=====");
            foreach (var item in freeSoftwares)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("========================");

            Console.ReadKey();
        }

        private static void PrintCollection(SoftwareCollection softwares)
        {
            foreach (var software in softwares)
            {
                if (software is FreeSoftware)
                {
                    Console.WriteLine((software as FreeSoftware));
                }
                else if (software is SharewareSoftware)
                {
                    Console.WriteLine((software as SharewareSoftware));
                }
                else if (software is ProprietarySoftware)
                {
                    Console.WriteLine((software as ProprietarySoftware));
                }
                else
                {
                    Console.WriteLine(software);
                }
                Console.WriteLine();
            }
        }
    }
}
