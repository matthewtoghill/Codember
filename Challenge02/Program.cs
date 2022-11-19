using System.Text;

namespace Challenge02;

public static class Program
{
    private static readonly string _input = File.ReadAllText(@"..\..\..\..\Data\challenge02.txt");
    private static readonly string _mail = "73 107110111119 121111117 121111117 100111 110111116 107110111119 109101 73 97109 1199711699104105110103 121111117 73 97109 102111108108111119105110103 121111117 68111 121111117 11997110116 116111 11210897121 8010897121 119105116104 109101 79107 7610111639115 11210897121 82117110 116104105115 9911110910997110100 11511798109105116 116561181061045651505752561029911097108";

    private static void Main()
    {
        var message = TranslateMessage(_input);
        Console.WriteLine(message);

        var mail = TranslateMessage(_mail);
        Console.WriteLine(mail);
    }

    private static string TranslateMessage(string message)
    {
        var result = new StringBuilder();

        for (int i = 0; i < message.Length; i++)
        {
            var len = message[i] switch
            {
                '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9' => 2,
                '1' => 3,
                _ => 1
            };

            result.Append(len == 1 ? ' ' : (char)int.Parse(message[i..(i + len)]));
            i += len - 1;
        }

        return result.ToString();
    }
}
