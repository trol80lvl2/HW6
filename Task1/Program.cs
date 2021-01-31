using System;
using System.Diagnostics;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Search(IPrimarySearcher searcher, int leftBorder, int rightBorder)
        {
            try
            {
                int max = Enumerable.Range(leftBorder, rightBorder - leftBorder + 1).Max();
                int min = leftBorder < 2 ? 2 : leftBorder;
                Stopwatch sw = new Stopwatch();
                Console.Clear();
                Console.WriteLine("Processing...");
                sw.Start();
                int count = searcher.SearchPrimary(min, max);
                Console.Clear();
                sw.Stop();
                Console.WriteLine($"{searcher.MethodName} in range [{leftBorder};{rightBorder})");
                Console.WriteLine($"Time elapsed {sw.ElapsedMilliseconds} ms. Founded {count} numbers");
            }
            catch
            {
                Console.Clear();
                Console.WriteLine($"In your range primary numbers can not be found");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("'LINQ-PLINQ Comparer' made by Roman Holub");

            int leftBorder, rightBorder;
            IPrimarySearcher[] searchers = new IPrimarySearcher[] { new LinqPrimarySearcher(), new PlinqPrimarySearcher() };

            while (true)
            {
                do
                {
                    Console.Write("Enter the left border of range->");
                }
                while (!int.TryParse(Console.ReadLine(), out leftBorder));

                do
                {
                    Console.Write("Enter the right border of range->");
                }
                while (!int.TryParse(Console.ReadLine(), out rightBorder));

                bool isWaitingKey = true;
                while (isWaitingKey)
                {
                    Console.Clear();
                    Console.WriteLine("Choose the search way. To enter new range press 'esc'");
                    Console.WriteLine("1.LINQ(sequential search)");
                    Console.WriteLine("2.PLINQ(parallel search)");
                    var key = Console.ReadKey(true).KeyChar;

                    if (Char.IsDigit(key))
                    {
                        int keyValue = int.Parse(key.ToString());
                        if(keyValue > 0 && keyValue <= searchers.Count())
                        {
                            Search(searchers[keyValue - 1], leftBorder, rightBorder);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        if (key == 27) //esc
                        {
                            Console.Clear();
                            isWaitingKey = false;
                        }
                    }
                }
            }       
        }
    }
}
