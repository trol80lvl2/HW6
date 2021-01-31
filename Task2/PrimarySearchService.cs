using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class PrimarySearchService
    {
        public List<int> PrimesList { get; set; } = new List<int>();
        public void PrimarySearch(object fromTo)
        {
            Settings settings = fromTo as Settings;
            for (int i = settings.PrimesFrom; i < settings.PrimesTo; i++)
            {
                if (isSimple(i))
                {
                    lock (PrimesList)
                    {
                        if(!PrimesList.Exists(x => x == i))
                        {
                            PrimesList.Add(i);
                        }
                    }
                }
            }
        }
        private bool isSimple(int N)
        {
            if (N < 2)
                return false;
            for (int i = 2; i <= (N / 2); i++)
            {
                if (N % i == 0)
                    return false;
            }
            return true;
        }
        public List<int> GetResultCollection() => PrimesList.OrderBy(x=>x).ToList();
    }
}
