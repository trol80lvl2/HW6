using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var json = await File.ReadAllTextAsync("settings.json");
                var settings = JsonSerializer.Deserialize<Settings[]>(json);

                PrimarySearchService searchService = new PrimarySearchService();
                Stopwatch sw = new Stopwatch();
                Thread[] threads = new Thread[settings.Length];

                sw.Start();
                for(int i = 0; i < threads.Length; i++)
                {
                    threads[i] = new Thread(new ParameterizedThreadStart(searchService.PrimarySearch));
                    threads[i].Start(settings[i]);
                }
                for (int i = 0; i < threads.Length; i++)
                {
                    threads[i].Join();
                }
                sw.Stop();

                var primes = searchService.GetResultCollection();
                TimeSpan time = sw.Elapsed;
                Result result = new Result(true, null, time.ToString(), primes);

                File.WriteAllText("result.json", JsonSerializer.Serialize(result));
            }
            catch (JsonException)
            {
                Result result;
                if (File.Exists("settings.json"))
                    result = new Result(false, "Unable to parse settings.json file", "00:00:00", new List<int>());
                else
                    result = new Result(false, "Settings file does not exist", "00:00:00", new List<int>());


                File.WriteAllText("result.json", JsonSerializer.Serialize(result));
            }
            catch(Exception e)
            {
                Result result = new Result(false, e.Message, "00:00:00", new List<int>());
                File.WriteAllText("result.json", JsonSerializer.Serialize(result));
            }
        }
    }
}
