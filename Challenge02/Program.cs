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
            switch (_input[i])
            {
                case '8':
                case '9':
                    message.Append((char)int.Parse(_input[i..(i + 2)]));
                    i++;
                    break;
                case '1':
                    message.Append((char)int.Parse(_input[i..(i + 3)]));
                    i += 2;
                    break;
                default:
                    message.Append(' ');
                    break;
            }
        }

        Console.WriteLine(message);
    }
}
