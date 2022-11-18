using System.Text;

namespace Challenge02;

public static class Program
{
    private static readonly string _input = File.ReadAllText(@"..\..\..\..\Data\challenge02.txt");
    private static void Main()
    {
        var message = new StringBuilder();

        for (int i = 0; i < _input.Length; i++)
        {
            var len = _input[i] switch
            {
                '8' or '9' => 2,
                '1' => 3,
                _ => 1
            };

            message.Append(len == 1 ? ' ' : (char)int.Parse(_input[i..(i + len)]));
            i += len - 1;
        }

        Console.WriteLine(message);
    }
}
