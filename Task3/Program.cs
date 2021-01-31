using System;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("'Unique login issuing service' made by Roman Holub");
            ThreadWorker threadWorker = new ThreadWorker();
            int threadsCount = 0;
            do
            {
                Console.Write("Enter count of threads->");
            }
            while (!int.TryParse(Console.ReadLine(),out threadsCount));

            Thread[] threads = new Thread[threadsCount];

            await LoginService.GenerateLoginsAsync(100);
            var logins = await LoginService.GetLoginsAsync();

            while (logins.Count > 0)
            {
                for(int i = 0; i < threads.Length; i++)
                { 
                    logins.TryDequeue(out Credentials login);
                    threads[i] = new Thread(new ParameterizedThreadStart(threadWorker.TryLogin));
                    threads[i].Start(login);

                    if (logins.Count == 0)
                        break;
                }
                for(int i = 0; i < threads.Length; i++)
                {
                        threads[i]?.Join();
                }
            }

            string json = JsonSerializer.Serialize(threadWorker.GetCounters());
            await File.WriteAllTextAsync("result.json", json);
        }
    }
}
