namespace Backend.Models;

public sealed record SoundboardSound
{
	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("sound_id")]
	public string Id { get; set; }

	[JsonPropertyName("guild_id")]
	public string GuildId { get; set; }
}