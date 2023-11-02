namespace Challenge01;

public static class Program
{
    private static readonly string[] _input = File.ReadAllText(@"..\..\..\..\Data\challenge01.txt").Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
    private static void Main()
    {
        var users = _input.Select(x => new User(x));

        var validUsers = users.Where(x => x.HasRequiredData()).ToList();

        Console.WriteLine($"Valid users: {validUsers.Count}");
        Console.WriteLine($"Last valid: {validUsers.Last().Username}");
        Console.WriteLine($"Solution: {validUsers.Count}{validUsers.Last().Username}");
    }
}
