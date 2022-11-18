namespace Challenge01;

public class User
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int? Age { get; set; }
    public string? Location { get; set; }
    public int? Followers { get; set; }

    public User(string input)
    {
        var split = input.Split(new[] { "\n", " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
        split.ForEach(TryParseKeyValuePair);
    }

    public bool HasRequiredData()
        => Username is not null && Email is not null && Password is not null && Age is not null && Location is not null && Followers is not null;

    public void TryParseKeyValuePair(string keyValuePair)
    {
        var split = keyValuePair.Trim().Split(':');
        TryParse(split[0], split[1]);
    }

    public void TryParse(string key, string value)
    {
        if (key is null || value is null) return;

        switch (key)
        {
            case "usr": Username = value;               break;
            case "eme": Email = value;                  break;
            case "psw": Password = value;               break;
            case "age": Age = int.Parse(value);         break;
            case "loc": Location = value;               break;
            case "fll": Followers = int.Parse(value);   break;
            default: break;
        }
    }
}
