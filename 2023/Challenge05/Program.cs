using System.Buffers;
using System.Text.RegularExpressions;

namespace Challenge05;

public partial class Program
{
    private static readonly string[] _input = File.ReadAllLines(@"..\..\..\..\Data\challenge05.txt");
    private static void Main()
    {
        var result = "";
        foreach (var item in _input)
        {
            var split = item.Split(',');
            var username = split[1];
            if (!IsValid(split[0], username, split[2], split[3], split[4]))
                result += username[0];
        }

        Console.WriteLine(result);
    }

    private const string alphaNumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
    private static SearchValues<char> alphaNumericVals = SearchValues.Create(alphaNumericChars);

    private static bool IsValid(string id, string username, string email, string age, string location)
    {
        if (string.IsNullOrWhiteSpace(id)) return false;
        if (string.IsNullOrWhiteSpace(username)) return false;
        if (string.IsNullOrWhiteSpace(email)) return false;
        if (!string.IsNullOrWhiteSpace(age) && !int.TryParse(age, out int _)) return false;
        if (id.AsSpan().IndexOfAnyExcept(alphaNumericVals) >= 0) return false;
        if (username.AsSpan().IndexOfAnyExcept(alphaNumericVals) >= 0) return false;
        if (!EmailRegex().IsMatch(email)) return false;

        return true;
    }

    [GeneratedRegex("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")]
    private static partial Regex EmailRegex();
}
