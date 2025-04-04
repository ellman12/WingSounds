namespace Backend;

public sealed record Config
{
	public string LoginToken { get; init; }

	public string Password { get; init; }

	public ulong UserId { get; init; }

	public ulong[] ServerIds { get; init; }

	public ulong BotChannelId { get; init; }

	public ulong DefaultVoiceChannelId { get; init; }

	public string ServerUrl { get; init; }

	///Read in config.json from project root and parse it.
	public static Config FromJson()
	{
		#if DEBUG
		string path = Path.Combine(Program.ProjectRoot, "config.json");
		#else
		string path = "/app/config.json";
		#endif

		return FromJson(path);
	}

	public static Config FromJson(string path)
	{
		return String.IsNullOrWhiteSpace(path) ? FromJson() : JsonSerializer.Deserialize<Config>(File.ReadAllText(path));
	}
}