
namespace Task1
{
    public interface IPrimarySearcher
    {
        string MethodName { get; }
        int SearchPrimary(int start, int finish);
    }
}
