namespace Challenge02;

public class Program
{
    private static readonly string _input = File.ReadAllText(@"..\..\..\..\Data\challenge02.txt");
    private static void Main()
    {
        var value = 0;
        _input.ToList().ForEach(c => value = GetOperation(c).Invoke(value));
    }

    public static Func<int, int> GetOperation(char command)
        => command switch
        {
            '#' => x => x + 1,
            '@' => x => x - 1,
            '*' => x => x * x,
            '&' => x => { Console.Write(x); return x; },
            _ => throw new ArgumentException()
        };
}

