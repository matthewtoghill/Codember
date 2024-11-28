namespace Challenge01;

public class Program
{
    private static readonly string[] _input = File.ReadAllText(@"..\..\..\..\Data\challenge01.txt").Split(' ');

    private static void Main()
    {
        List<int> code = _input[0].ToArray().Select(x => x - '0').ToList();
        var index = 0;
        var length = _input[0].Length;

        foreach (var item in _input[1])
        {
            if (item == 'U') code[index] = code[index] == 9 ? 0 : code[index] + 1;
            if (item == 'D') code[index] = code[index] == 0 ? 9 : code[index] - 1;
            if (item == 'R') index = (index + 1) % length;
            if (item == 'L') index = (index - 1) % length;
            if (index < 0) index = length - 1;
            if (index > length) index = 0;
        }

        code.ForEach(Console.Write);
    }
}
