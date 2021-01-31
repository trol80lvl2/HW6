using System.Linq;

namespace Task1
{
    public class PlinqPrimarySearcher : IPrimarySearcher
    {
        public string MethodName 
        { 
            get => "PLINQ"; 
        }

        public int SearchPrimary(int start, int finish) => (from s in Enumerable.Range(start, finish - start).AsParallel()
                                                            where Enumerable.Range(2, s / 2 - 1).All(x => s % x != 0)
                                                            select s).Count();
    }
}
