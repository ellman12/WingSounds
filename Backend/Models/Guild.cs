namespace Backend.Models;

public sealed record Guild
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

}